using Bindicate.Attributes.Options;

namespace CleanArchitectureTemplate.Infrastructure;

[RegisterOptions("Connections")]
public class PersistanceOptions
{
    public string ConnectionString { get; set; } = "";

    public string Schema { get; set; } = "";
}
