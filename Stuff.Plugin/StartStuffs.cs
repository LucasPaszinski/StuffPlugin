using _3S.CoDeSys.Core;
using _3S.CoDeSys.Core.Components;
using _3S.CoDeSys.Core.LanguageModel;
using System;

namespace Stuff
{
    [TypeGuid("{22dce90d-697a-4cf2-979b-972af0475734}"), SystemInterface("Stuff.StartStuffs")]
    public class StartStuffs : ISystemInstanceRequiresInitialization
    {
        public void OnAllSystemInstancesAvailable()
        {
            APEnviroment.LanguageModelMgr.BeforeCompile += LanguageModelMgr_BeforeCompile;
        }

        private void LanguageModelMgr_BeforeCompile(object sender, CompileEventArgs e)
        {
            var project = SystemInstances.Engine.Projects.PrimaryProject;

            APEnviroment.LanguageModelMgr.PutLanguageModel(new LangModelTestIfRetainAfterClosing(e.ApplicationGuid), true);
        }
    }    
}
