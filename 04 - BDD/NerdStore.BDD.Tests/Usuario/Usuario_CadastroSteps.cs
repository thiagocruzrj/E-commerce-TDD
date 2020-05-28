using TechTalk.SpecFlow;

namespace NerdStore.BDD.Tests.Usuario
{
    [Binding]
    public class Usuario_CadastroSteps
    {
        [When(@"Ele clicar em registrar")]
        public void QuandoEleClicarEmRegistrar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Preencher os dados do formulario")]
        public void QuandoPreencherOsDadosDoFormulario(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Clicar no botão registrar")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Preencher os dados do formulario com uma senha sem maiusculas")]
        public void QuandoPreencherOsDadosDoFormularioComUmaSenhaSemMaiusculas(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Preencher os dados do formulario com uma senha caracter especial")]
        public void QuandoPreencherOsDadosDoFormularioComUmaSenhaCaracterEspecial(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Ele receberá uma mensagem de error que a senha precisa conter uma letra maiuscula")]
        public void EntaoEleReceberaUmaMensagemDeErrorQueASenhaPrecisaConterUmaLetraMaiuscula()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Ele receberá uma mensagem de error que a senha precisa conter um caracter especial")]
        public void EntaoEleReceberaUmaMensagemDeErrorQueASenhaPrecisaConterUmCaracterEspecial()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
