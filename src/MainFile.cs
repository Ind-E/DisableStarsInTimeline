using Godot;
using MegaCrit.Sts2.Core.Modding;

namespace DisableStarsInTimeline;

[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "DisableStarsInTimeline";

    public static void Initialize()
    {
        if (Engine.GetMainLoop() is SceneTree tree)
        {
            tree.NodeAdded += OnNodeAdded;
        }
    }

    private static async void OnNodeAdded(Node node)
    {
        if (
            node is not GpuParticles2D particles
            || (
                particles.GetParent().Name != "TimelineScreen"
                && (particles.Name == "StarsBg" || particles.Name == "StarsFg")
            )
        )
        {
            return;
        }

        particles.Visible = false;
    }
}
