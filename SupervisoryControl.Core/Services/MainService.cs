using SupervisoryControl.Core.Interfaces;

namespace SupervisoryControl.Core.Services;

public class MainService :IMainService {
    public string GetWelcomeMessage() {
        var data = DateTime.Now.ToString();
        return data;
    }
}