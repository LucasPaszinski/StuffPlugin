namespace Stuff
{
    using _3S.CoDeSys.Core;
    using _3S.CoDeSys.Core.ComponentModel;
    using _3S.CoDeSys.Core.LanguageModel;

    class DependencyBag : IDependencyInjectable
    {
        public DependencyBag()
        {
            ComponentModel.Singleton.InjectDependencies(this, GetType());
        }

        public void InjectionComplete() { }

        [InjectSingleInstance(Shared = true)]
        public ISharedSingleInstanceProvider<ILanguageModelManager> LanguageModelManagerProvider { get; private set; }
    }
}
