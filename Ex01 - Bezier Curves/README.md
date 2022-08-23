<h1>Exercício 1 - Movimentando o ratinho de acordo com curvas</h1>

Aqui é possivel encontrar a pasta do projeto Unity "Mouse 2022", que contém tanto o projeto quanto uma pasta "Builds" com a versão já buildada do ambiente que foi modificado a partir do projeto base oferecido.

<h2>Sobre o projeto</h2>
Alguns detalhes importantes caso deseje modificar o projeto

<h3>Opções disponíveis no ratinho</h3>
Selecionando um dos ratinho é possivel ver o componente "Seeker" presente nele, neste você pode modificar:
<ul>
  <li>Target: um Transform que será o ponto final da trajetória do ratinho</li>
  <li>Curve Prefab: uma curva que ditará a variação de velocidade/posição do ratinho ao longo da trajetória - mais sobre as curvas abaixo</li>
  <li>Time To Target In Sec: quanto tempo, em segundos você quer que o ratinho leve para chegar ao fim da trajetória</li>
</ul>
  
<h3>Utilização das curvas</h3>
Foram criadas 4 curvas diferentes, estas estão presentes na pasta "Prefabs", visto que cada uma foi criada como sendo um prefab diferente, todas estão nomeadas de acordo com seu comportamento.
Para utilizar uma curva como comportamento de um ratinho, selecione o ratinho e arraste o prefab desejado para o campo "Curve Prefab" no Script "Seeker" do ratinho.

<h3>Edição/Criação das curvas de Bezier</h3>
Eu optei por apenas criar curvas de Bezier, portanto não existe opção de criar outro tipo de curva.

Para modificar uma curva, foi criada uma interface visual que facilita esse processo, assim não é necessário conhecimento da fórmula, nem mesmo o input de valores específicos.

Recomendo duplicar uma das curvas existentes para manter o original em vez de editar as já criadas.
Abrindo um dos prefabs de curvas é possivel ver a interface que foi criada. Garanta que está usando a visão 2D da Unity para um melhor controle. Modificando a posição dos objetos "Control1" e "Control2" você será capaz de ver em tempo real(não é necessário dar play na cena) a forma da curva ser alterada. 

Ao clicar no objeto raiz da cena é possível ver que esse contém o componente "BezierCurve", nesse você ainda recebe um parâmetro para modificar um pouco mais o comportamente do ratinho, presente no campo "Steps". Esse parâmetro não altera "de fato" o comportamento do ratinho, mas sim a visualização da cena, em suma isso determina em quantas posições diferentes o caminho total vai ser dividido, assim, o maior que seja este número mais suave/fluido será o movimento do ratinho, o padrão está setado para 200, que traz um resultado bastante fluido para o ambiente criado, lembre-se que um número muito alto pode causar problemas de performance.

Assim que estiver satisfeito com a curva, basta seguir a orientação da seção acima - arraste a curva para o campo devido no ratinho.
