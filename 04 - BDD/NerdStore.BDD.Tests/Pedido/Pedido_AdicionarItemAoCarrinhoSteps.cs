using TechTalk.SpecFlow;

namespace NerdStore.BDD.Tests.Pedido
{
    [Binding]
    public class Pedido_AdicionarItemAoCarrinhoSteps
    {
        [Given(@"Que um produto esteja na vitrine")]
        public void DadoQueUmProdutoEstejaNaVitrine()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Esteja desponivel no estoque")]
        public void DadoEstejaDesponivelNoEstoque()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"O usuario esteja logado")]
        public void DadoOUsuarioEstejaLogado()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"O mesmo produto já tenha sido adicionado ao carrinho anteriormente")]
        public void DadoOMesmoProdutoJaTenhaSidoAdicionadoAoCarrinhoAnteriormente()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"O usuario adicionar uma unidade ao carrinho")]
        public void QuandoOUsuarioAdicionarUmaUnidadeAoCarrinho()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"O usuario adicionar um item acima da quantidade máxima permitida")]
        public void QuandoOUsuarioAdicionarUmItemAcimaDaQuantidadeMaximaPermitida()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"O usuario adicionar a quantidade maxima permitida ao carrinho")]
        public void QuandoOUsuarioAdicionarAQuantidadeMaximaPermitidaAoCarrinho()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"O usuario será direcionado ao resumo da compra")]
        public void EntaoOUsuarioSeraDirecionadoAoResumoDaCompra()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"O valor total do pedido será exatamente o valor do item adicionado")]
        public void EntaoOValorTotalDoPedidoSeraExatamenteOValorDoItemAdicionado()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Receberá uma mensagem de error mencionando que foi ultrapassada a quantidade limite")]
        public void EntaoReceberaUmaMensagemDeErrorMencionandoQueFoiUltrapassadaAQuantidadeLimite()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"A quantidade de itens daquele produto terá sido acrescida em uma unidade a mais")]
        public void EntaoAQuantidadeDeItensDaqueleProdutoTeraSidoAcrescidaEmUmaUnidadeAMais()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"O valor total do pedido será a multiplicação da quantidade de itens pelo valor unitário")]
        public void EntaoOValorTotalDoPedidoSeraAMultiplicacaoDaQuantidadeDeItensPeloValorUnitario()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Receberá a mensagem de error mencionando que foi ultrapassada a quantidade limite")]
        public void EntaoReceberaAMensagemDeErrorMencionandoQueFoiUltrapassadaAQuantidadeLimite()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
