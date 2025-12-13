using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

public sealed class Session
{
    private ISessionState _sessionState = new DisconnectedState();

    public PrintingEntities PrintingEntities { get; } = new();

    public string RootPath => _sessionState.BasePath;

    public string CurrentPath => _sessionState.CurrentPath;

    public bool IsConnected => _sessionState is ConnectedState;

    public IFileSystem FileSystem => _sessionState.FileSystem;

    public void UpdateState(ISessionState state)
    {
        _sessionState = state;
    }

    public bool ChangePath(string newPath)
    {
        return _sessionState.TryChangePath(newPath);
    }

    public bool Connect(IFileSystem fileSystem, string basePath)
    {
        return _sessionState.TryConnect(this, fileSystem, basePath);
    }

    public bool Disconnect()
    {
        return _sessionState.TryDisconnect(this);
    }
}
