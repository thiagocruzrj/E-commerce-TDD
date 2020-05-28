using TechTalk.SpecFlow;

namespace NerdStore.BDD.Tests.Usuario
{
    [Binding]
    public class CommomSteps
    {
        [Then(@"Uma saudação com seu e-mail será exibida no menu superior")]
        public void EntaoUmaSaudacaoComSeuE_MailSeraExibidaNoMenuSuperior()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Que o visitatnte está acessando o site da loja")]
        public void DadoQueOVisitatnteEstaAcessandoOSiteDaLoja()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Ele será redirecionado na vitrine")]
        public void EntaoEleSeraRedirecionadoNaVitrine()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
