Funcionalidade: Usuário - Cadastro
	Como um visitante da loja
	Eu desejo me cadastrar como usuário
	Para que possa realizar compras no site

Cenário: Cadastro de usuário com sucesso
Dado Que o visitatnte está acessando o site da loja
Quando Ele clicar em registrar
E Preencher os dados do formulario
		| Dados                |
		| E-mail               |
		| Senha                |
		| Confirmação da Senha |
E Clicar no botão registrar
Então Ele será redirecionado na vitrine
E Uma saudação com seu e-mail será exibida no menu superior

Cenário: Cadastro com senha sem maiusculas

Cenário: Cadastro com senha sem caractere especial
