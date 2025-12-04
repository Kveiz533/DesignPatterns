using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public abstract class BaseParser<TBuilder> : ICommandParser
    where TBuilder : ICommandBuilder
{
    private readonly ICommandParser? _subChainCommands;
    private readonly IArgumentParser<TBuilder>? _subChainArguments;
    private ICommandParser? _nextParser;

    protected BaseParser(
        ICommandParser? subChainCommands,
        IArgumentParser<TBuilder>? subChainArguments)
    {
        _subChainCommands = subChainCommands;
        _subChainArguments = subChainArguments;
    }

    public void AddNext(ICommandParser nextParser)
    {
        if (_nextParser is not null)
        {
            _nextParser.AddNext(nextParser);
        }
        else
        {
            _nextParser = nextParser;
        }
    }

    public ParseResult Parse(IArgumentIterator iterator)
    {
        if (iterator.Current() != CommandName)
        {
            return _nextParser?.Parse(iterator)
                   ?? new ParseResult.FailureWithParsing("Invalid command");
        }

        iterator.MoveNext();

        if (_subChainCommands is not null && iterator.Current() is not null)
        {
            ParseResult subResult = _subChainCommands.Parse(iterator);
            if (subResult is ParseResult.Success)
            {
                return subResult;
            }
            else if (subResult is ParseResult.FailureWithArguments failure)
            {
                return failure;
            }
        }

        TBuilder builder = CreateBuilder();
        while (iterator.Current() is not null)
        {
            Console.WriteLine(iterator.Current());
            bool handled = false;

            if (_subChainArguments is not null)
            {
                ParseResult parseResult = _subChainArguments.TryParse(iterator, builder);

                if (parseResult is ParseResult.Success)
                {
                    handled = true;
                }
                else if (parseResult is ParseResult.FailureWithArguments failure)
                {
                    return new ParseResult.FailureWithArguments(failure.Message);
                }
            }

            Console.WriteLine(handled);
            if (!handled)
            {
                return new ParseResult.FailureWithArguments("Invalid argument");
            }
        }

        return new ParseResult.Success(builder);
    }

    protected abstract string CommandName { get; }

    protected abstract TBuilder CreateBuilder();
}