Funcionalidade: Pedido - Adicionar Item ao Carrinho
	Como um usuário
	Eu desejo colocar um item no carrinho
	Para que eu posso comprá-lo posteriormente

Cenário: Adicionar item com sucesso a um novo pedido
Dado Que um produto esteja na vitrine
E Esteja desponivel no estoque
E O usuario esteja logado
Quando O usuario acionar uma unidade ao carrinho
Entao O usuario será redirecionado ao resumo da compra
E O valor total do pedido será exatamente o valor do item adicionado

