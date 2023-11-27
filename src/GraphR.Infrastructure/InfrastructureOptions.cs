using Bindicate.Attributes.Options;

namespace GrapR.Infrastructure;

[RegisterOptions("Connections")]
public class InfrastructureOptions
{
    public string ConnectionString { get; set; } = "";

    public string Schema { get; set; } = "";
}
