namespace SupervisoryControl.Core.Interfaces;

public interface IMySqlService {
    bool TryConnect(out string message);
}

