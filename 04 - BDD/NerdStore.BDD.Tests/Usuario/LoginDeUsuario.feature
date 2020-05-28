Funcionalidade: Usuário - Login
	Como usuario
	Eu desejo realizar o login
	Para que eu possa acessar as demais funcionalidades

Cenário: Realizar login com sucesso
Dado Que o visitante está cessando o site da loja
Quando Ele clicar em login
E Preencher os dados do formulário de login
		| Dado   |
		| E-mail |
		| Senha  |
E Clicar no botão login
Então Ele será redirecionado para a vitrine
E Uma saudação com seu e-mail será exibida no menu superiro
