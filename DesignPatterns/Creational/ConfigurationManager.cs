
/* Task 1: Create a ConfigurationManager class that stores application settings like theme,
language, and version
It should always return the same instance wherever used. */
namespace Task1
{
    sealed class ConfigurationManager
{
    private static ConfigurationManager? _item;
    public string? Theme { get; set; }
    public string? Language { get; set; }
    public string? Version { get; set; }
    private ConfigurationManager() {}
    public static ConfigurationManager Instance
    {
        get
        {
            if (_item == null)
                _item = new ConfigurationManager();
            return _item;
        }
    }
}
}



