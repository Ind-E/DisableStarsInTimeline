using Godot;
using MegaCrit.Sts2.Core.Modding;

namespace DisableStarsInTimeline;

[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "DisableStarsInTimeline";

    static SceneTree? tree;

    static void Initialize()
    {
        tree = Engine.GetMainLoop() as SceneTree;
        if (tree is not null)
        {
            tree.NodeAdded += OnNodeAdded;
        }
    }

    static async void OnNodeAdded(Node node)
    {
        if (
            tree is null
            || node is not GpuParticles2D particles
            || particles.GetParent().Name != "TimelineScreen"
                && (particles.Name == "StarsBg" || particles.Name == "StarsFg")
        )
            return;

        particles.Visible = false;
    }
}
