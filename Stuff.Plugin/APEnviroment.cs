namespace Stuff
{
    using System;
    using _3S.CoDeSys.Core;
    using _3S.CoDeSys.Core.LanguageModel;

    public static class APEnviroment
    {
        private static Lazy<DependencyBag> lazyBag =
            new Lazy<DependencyBag>(() => new DependencyBag());

        public static ILanguageModelManager LanguageModelMgr
        {
            get { return lazyBag.Value.LanguageModelManagerProvider.Value; }
        }
    }
}
