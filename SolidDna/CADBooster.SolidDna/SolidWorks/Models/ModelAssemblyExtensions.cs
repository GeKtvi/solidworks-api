using SolidWorks.Interop.sldworks;
using System.Collections.Generic;
using System.Linq;

namespace CADBooster.SolidDna
{
    public class ComponentNode
    {
        public ComponentNode Parent { get; }
        public Component Component { get; }
        public IEnumerable<ComponentNode> Children { get; }

        internal ComponentNode(ComponentNode parent, Component component, ICompositeDisposable compositeDisposable)
        {
            Parent = parent;
            Component = component;
            Children = (Component.UnsafeObject.GetChildren() as object[] ?? Enumerable.Empty<object>())
                .Cast<Component2>()
                    .WrapDnaObjects(compositeDisposable, x => new Component(x))
                    .Select(x => new ComponentNode(this, x, compositeDisposable));
        }
    }

    public static class ModelAssemblyExtensions
    {
        public static ComponentNode GetRootComponentNode(this Model model, ICompositeDisposable compositeDisposable = null)
            => model.GetRootComponentNode(null, compositeDisposable);

        public static ComponentNode GetRootComponentNode(this Model model, string configurationName, ICompositeDisposable compositeDisposable = null)
        {
            var component = GetRootComponentFromConfiguration(model, configurationName);
            return new ComponentNode(null, component, compositeDisposable ?? DummyCompositeDisposable.Default);
        }

        public static IEnumerable<ComponentNode> GetComponentNodes(this Model model, ICompositeDisposable compositeDisposable = null)
            => model.GetComponentNodes(null, compositeDisposable);

        public static IEnumerable<ComponentNode> GetComponentNodes(this Model model, string configurationName, ICompositeDisposable compositeDisposable = null)
        {
            var component = GetRootComponentFromConfiguration(model, configurationName);

            return new ComponentNode(null, component, compositeDisposable ?? DummyCompositeDisposable.Default).Children;
        }

        private static Component GetRootComponentFromConfiguration(Model model, string configurationName)
        {
            var modelConfiguration = configurationName is null
                ? model.ActiveConfiguration
                : model.GetConfiguration(configurationName);

            var component = new Component(modelConfiguration.UnsafeObject.GetRootComponent3(true));

            return component;
        }
    }
}
