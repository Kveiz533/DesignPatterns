using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.Archiver;
using Itmo.ObjectOrientedProgramming.Lab2.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab2.UserEntities;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class DistributionSystemTests
{
    [Fact]
    public void DistributionSystem_SendMessageToUser_NotRead()
    {
        // Arrange
        var user = new User();
        var addressee = new AddresseeUser(user);
        var message = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());

        // Act
        addressee.ReceiveMessage(message);

        // Assert
        Assert.IsType<MessageStatus.NotRead>(user.GetMessageStatus(message));
    }

    [Fact]
    public void DistributionSystem_SendMessageToUserAndThenRead_Read()
    {
        // Arrange
        var user = new User();
        var addressee = new AddresseeUser(user);
        var message = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());

        // Act
        addressee.ReceiveMessage(message);
        user.ReadMessage(message);

        // Assert
        Assert.IsType<MessageStatus.Read>(user.GetMessageStatus(message));
    }

    [Fact]
    public void DistributionSystem_SendMessageToUserAndThenReadTwoTimes_AlreadyRead()
    {
        // Arrange
        var user = new User();
        var addressee = new AddresseeUser(user);
        var message = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());

        // Act
        addressee.ReceiveMessage(message);
        user.ReadMessage(message);
        MarkResult status = user.ReadMessage(message);

        // Assert
        Assert.IsType<MarkResult.AlreadyMarked>(status);
    }

    [Fact]
    public void DistributionSystem_SendMessageToUserThatDoesNotMeetTheImportanceLevel_NotSent()
    {
        // Arrange
        IAddressee mockInnerAddressee = Substitute.For<IAddressee>();
        var addressee = new FilterAddresseeProxy(mockInnerAddressee, ImportanceLevel.High());
        var message = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());

        // Act
        addressee.ReceiveMessage(message);

        // Assert
        mockInnerAddressee.DidNotReceive().ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void DistributionSystem_SendMessageToUserThatWithLogger_Logged()
    {
        // Arrange
        var user = new User();
        ILogger mockInnerLogger = Substitute.For<ILogger>();
        var addressee = new LoggerAddresseeDecorator(new AddresseeUser(user), mockInnerLogger);
        var message = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());

        // Act
        addressee.ReceiveMessage(message);

        // Assert
        mockInnerLogger.Received(1).Log(Arg.Any<Message>());
    }

    [Fact]
    public void DistributionSystem_SendMessageToAddresseeArchiverWithArchiverFormatter_Archived()
    {
        // Arrange
        IArchiver mockInnerArchiver = Substitute.For<IArchiver>();
        var addressee = new AddresseeArchiver(mockInnerArchiver);
        var message = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());

        // Act
        addressee.ReceiveMessage(message);

        // Assert
        mockInnerArchiver.Received(1).Archive(Arg.Any<Message>());
    }

    [Fact]
    public void DistributionSystem_SendMessagesToUserWithDifferentImportanceLevel_OneSentAnotherNot()
    {
        // Arrange
        IAddressee mockInnerAddressee = Substitute.For<IAddressee>();
        var addresseeUser = new FilterAddresseeProxy(mockInnerAddressee, ImportanceLevel.Medium());
        var message1 = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.Low());
        var message2 = new Message(new Title("Hello"), new Body("World"), ImportanceLevel.High());

        // Act
        addresseeUser.ReceiveMessage(message1);
        addresseeUser.ReceiveMessage(message2);

        // Assert
        mockInnerAddressee.Received(1).ReceiveMessage(Arg.Any<Message>());
    }
}