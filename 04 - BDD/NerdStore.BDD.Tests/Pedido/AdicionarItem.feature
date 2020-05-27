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

Cenário: Adicionar itens acima do limite
Dado Que um produto esteja na vitrine
E E esteja disponivel no estoque
E O usuario esteja logado
Quando O usuario adicionar um item acima da quantidade máxima permitida
Então Receberá uma mensagem de error mencionando que foi ultrapassada a quantidade limite

Cenário: Adicionar item já exitente no carrinho
Dado Que um produto esteja na vitrine
E E esteja disponivel no estoque
E O usuario esteja logado
E O mesmo produto já tenha sido adicionado ao carrinho anteriormente
Quando O usuário adicionar uma unidade ao carrinho
Entao O usuário será redirecionado ao resume da compra
E A quantidade de itens daquele produto terá sido acrescida em uma unidade a mais
E O valor total do pedido será a multiplicação da quantidade de itens pelo valor unitário