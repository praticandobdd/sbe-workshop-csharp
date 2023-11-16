#language: pt
Funcionalidade: Estimar tempos de lasanha

Regra: Defina o tempo esperado de forno em minutos
Cenário: Minutos esperados no forno
#Então os minutos esperados no forno devem ser 40

Regra: Calcule o tempo restante no forno em minutos
Cenário: Minutos restantes no forno após vinte e cinco minutos
#Então os minutos restantes no forno devem ser 15 quando já se passaram 25

Cenário: Minutos restantes no forno após trinta e três minutos
#Então os minutos restantes no forno devem ser 7 quando já se passaram 33

Regra: Calcule o tempo de preparação em minutos
Cenário: Tempo de preparação em minutos para uma camada
#Então o tempo de preparação em minutos deve ser 2 quando 1 camada é adicionada
Cenário: Tempo de preparação em minutos para múltiplas camadas
#Então o tempo de preparação em minutos deve ser 4 quando 2 camadas são adicionadas

Regra: Calcule o tempo decorrido em minutos
Cenário: Tempo decorrido em minutos para uma camada
#Então o tempo decorrido em minutos deve ser 16 quando 3 camadas são adicionadas e já se passaram 10 minutos no forno
Cenário: Tempo decorrido em minutos para múltiplas camadas
#Então o tempo decorrido em minutos deve ser 11 quando 2 camadas são adicionadas e já se passaram 7 minutos no forno