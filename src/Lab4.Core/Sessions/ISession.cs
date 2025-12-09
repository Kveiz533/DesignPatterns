using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

public interface ISession
{
    IFileSystem FileSystem { get; }

    string RootPath { get; }

    string CurrentPath { get; }

    bool IsConnected { get; }

    void UpdateState(ISessionState state);

    bool ChangePath(string newPath);

    bool Connect(IFileSystem fileSystem, string basePath);

    bool Disconnect();
}