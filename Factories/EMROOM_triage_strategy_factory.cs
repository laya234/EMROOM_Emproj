using EMROOM_emproj.Strategies;

namespace EMROOM_emproj.Factories;

public class EMROOM_Triage_Strategy_Factory
{
    private readonly IServiceProvider _serviceProvider;
    
    public EMROOM_Triage_Strategy_Factory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public IEMROOM_Triage_Strategy GetStrategy(string strategyType)
    {
        return strategyType.ToLower() switch
        {
            "basic" => _serviceProvider.GetRequiredService<EMROOM_Basic_Triage_Strategy>(),
            "advanced" => _serviceProvider.GetRequiredService<EMROOM_Advanced_Triage_Strategy>(),
            _ => _serviceProvider.GetRequiredService<EMROOM_Basic_Triage_Strategy>()
        };
    }
}
