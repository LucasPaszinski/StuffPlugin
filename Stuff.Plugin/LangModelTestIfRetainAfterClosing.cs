using _3S.CoDeSys.Core.LanguageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuff
{
    public class LangModelTestIfRetainAfterClosing : IStructuredLanguageModelProvider, ILanguageModelProvider
    {
        public Guid ApplicationGuid = Guid.Empty;
        public Guid PlcDeviceGuid = Guid.Empty;

        public LangModelTestIfRetainAfterClosing(Guid appGuid)
        {
            ApplicationGuid = appGuid;
        }

        public string GetLanguageModel()
        {
            throw new NotImplementedException();
        }

        public ILanguageModel GetStructuredLanguageModel(ILanguageModelBuilder lmbuilder)
        {
            var languageModel = lmbuilder.CreateLanguageModel(this.ApplicationGuid, PlcDeviceGuid, Guid.Empty, string.Empty);

            languageModel.AddGlobalVariableList(CreateVfInitGvl());

            return languageModel;

            // Impremented GVL
            ILMGlobVarlist CreateVfInitGvl()
            {
                var gvl = CreateGvl(
                    "Yollo_GVL",
                    "b71a288a-9255-42f2-85d5-2a112982854e",
                    @"
VAR_GLOBAL
    {attribute 'hide'}
    Yollo : INT;
END_VAR");
                return gvl;
            }
            // Creates a GVL.
            ILMGlobVarlist CreateGvl(string gvlName, string gvlGuid, string gvlInterface)
            {
                var gvl = lmbuilder.CreateGlobVarlist(gvlName, new Guid(gvlGuid));
                gvl.Interface = ParseInterfaceSnippet(gvlInterface);

                return gvl;
            }
            // Parses an interface snippet.
            ISequenceStatement ParseInterfaceSnippet(string snippet)
            {
                var seqStatement = ((ILanguageModelBuilder3)lmbuilder).ParseInterfaceSnippet(snippet, false);

                return seqStatement;
            }
        }
    }
}
