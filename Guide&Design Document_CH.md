# 攻略/说明文档 #
<font color="grey">
 0.如果你没玩过Final Fantasy XIV...

- 本战斗设计基于一款名为Final Fantasy XIV（下称FFXIV）的MMORPG，和大多数经典的MMORPG的Raid Boss战斗一样，若干玩家分配至坦克、输出、治疗等职能，在走位躲避Boss技能和处理机制的同时，合理使用技能并互相配合来共同攻克Boss。其中，坦克职能需要持续吸引Boss的注意并承受来自Boss的大部分伤害，输出职能需要对Boss造成足够的伤害，治疗职能需要确保团队生存。

- FFXIV的Raid设计倾向于固定时间轴，Boss根据特定的时间轴使用技能，比较注重解谜和团队低容错的机制处理，随机性内容存在但是较少，比较考验走位的背板，只要不断熟悉如何走位处理机制，即可完成攻略。
- 本战斗设计存在一定的随机性和临场反应，不高但请合理处理。</font>

## 1.基本操作 ##


1. 选择好操作角色后，单击开始/暂停开始游戏，使用方向键或WASD进行移动，使用123键或JKL键使用技能。

- 未被选择的角色会自行移动并输出Boss。<br>
- 玩家死亡后会自动复活。所有玩家的血量、死亡次数、增益状态显示在左上角，当前操控玩家的增益状态还会显示在右下角。

- 战斗场地为一个半径20米的圆形，玩家不可越过场地边界，触碰场地边界不会死亡。
- 涉及到造成玩家伤害的部分以DPS和治疗血量为基准，坦克拥有额外的血量和减伤。伤害存在浮动，100%血量伤害不一定意味着死亡。

- 目前仅支持操作远程输出职能2，如果你想尝试使用技能，最大化输出的方式为1-1-1-3-2后不断1-1-3-2循环。
## 2.核心机制 ##
本场战斗的核心机制为管理Boss会给玩家赋予的Buff <img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，每次获得持续60秒。
   > <img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" >：身上附着有导电物质，下一次承受的雷电攻击会被引导至别处并赋予避雷的状态

 - 拥有该Buff后被范围攻击击中，这次攻击的范围会被改变，基本上而言，原来安全的地方会变危险，而原来危险的地方会变安全。
 
- 被改变后的攻击范围内如果也有持有该Buff的玩家，那这次攻击又会变为原本的范围。如果更多持有Buff的玩家在对应范围内，这次攻击的范围会被多次反转。
- 成功反转一次攻击后，<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 会消耗并变为<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" />。多个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 持有者在同一攻击范围内，只会随机消耗掉其中一个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />。
><img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" >：身上附着有导电物质，可以减轻雷电造成的伤害

- <img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" />的持续时间很短，但是可以大量减少范围攻击的伤害，一般用于连续反转攻击后，确保参与反转的玩家不会受到大量伤害。
- 持有<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" /> 时获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" /> 会被<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 覆盖。
- 继续介绍<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，如果玩家在持有<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 的情况下又获得了一个，那么<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 会变为Debuff <img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" />。
> <img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" >：身体里积蓄着过量电流，体力持续流失

- 持有该Debuff会每3秒受到约60%血量的伤害，持续30秒，尽管有治疗但基本意味着死亡。
- 持有该Debuff后不影响下一次获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，也不影响<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 转变为<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" />。
- 除此之外，也有别的方式可能会导致获得该Debuff。

总结获得Buff和Debuff的逻辑如下：

- 没有Buff时：可以获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，可以获得<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" />。
- 持有<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 时，继续获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 会转变为<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" />，反转范围攻击会转变为<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" />。
- 持有<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" /> 时，获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 会取消<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" /> 并获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />。
- 持有<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" /> 时，不影响<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 和<img src="https://s1.ax1x.com/2020/10/12/02CR7F.png" width = "20" height = "25" /> 的获得，如果继续获得<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" /> 会刷新其持续时间。
- 玩家死亡后，所有Buff和Debuff会被移除。


此外，Boss也拥有两个Buff：<img src="https://s1.ax1x.com/2020/10/12/02iZVO.png" width = "20" height = "25" />  <img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" />
> <img src="https://s1.ax1x.com/2020/10/12/02iZVO.png" width = "20" height = "25" >：攻击所造成的伤害提高，受到攻击的伤害减少


- <img src="https://s1.ax1x.com/2020/10/12/02iZVO.png" width = "20" height = "25" /> 可以叠加累计，每一档<img src="https://s1.ax1x.com/2020/10/12/02iZVO.png" width = "20" height = "25" />会赋予Boss 5%的攻击提高和5%的受伤减少，最多累计8层，一旦获得永久持有
- 每当玩家死亡会累计一层<img src="https://s1.ax1x.com/2020/10/12/02iZVO.png" width = "20" height = "25" />，特定机制也会累计。
- <img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" /> 与机制相关，其介绍见3.3部分。
## 3.主要机制 ##
###3.1 变压电流 ###
* Boss随机点名若干数量玩家，3秒后，被点名的玩家受到50%血量的单体伤害并获得<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />。
* 在读条时也会标记<img src="https://s1.ax1x.com/2020/10/12/02Pt3R.png" width = "15" height = "25" />玩家进行提示。
### 3.2 雷电冲击/雷电咆哮 (Thunder Strike/ Thunder Roll)
- Boss会随机二选一使用该技能，3秒读条后，雷电冲击对距离Boss10米以内的玩家造成100%血量伤害，雷电咆哮对距离10米以外的玩家造成100%血量伤害，没有范围提示。
- 这两个技能被<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 反转后刚好是对方的范围，即雷电冲击反转后变为雷电咆哮，反之亦然。
> <img src="https://s1.ax1x.com/2020/10/12/02Pdu6.png" width = "200" height = "200" />      <img src="https://s1.ax1x.com/2020/10/12/02PwDK.png" width = "200" height = "200" />　　　   　雷电冲击 　　　　　　　　　　　雷电咆哮 
###3.3 吸收/雷光电涌 (Absorb/ Lightning Surge)###
- 组合成<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 的检测机制，要求玩家不能持有任何<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />
- 吸收在2秒读条后，Boss会移除所有玩家的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> ，如果成功移除到了一个或以上的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，Boss会给自身赋予<img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" /> 的Buff。
> <img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" >：吸收了电流, 下一次雷光电涌将释放出大量闪电。

- 雷光电涌一般紧接着吸收，在3秒读条后，雷光电涌对所有玩家造成66%血量的单体伤害，如果Boss持有<img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" />，会移除<img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" /> 并额外赋予所有玩家<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" /> ，基本等于团灭。
### 3.4 审判打击/跨步电压 (Judgment Blow/ Step Volage)###
- 组合成对坦克的大伤害技能，但也和<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 有所相关。
- 审判打击在4秒读条后，对读条发动时的主坦克造成大量单体伤害，同时赋予其<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />。
- 在审判打击读条结束后的1秒后，Boss会立即以自身为中心朝向主坦克的方向的覆盖整个半场的范围攻击跨步电压，被<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 反转后范围会变为完全相反的半场。在攻击范围内的玩家将受到100%血量的伤害。
> <img src="https://s1.ax1x.com/2020/10/12/02PfDf.png" width = "200" height = "200" />　　　　　变压电流
###3.5 双重冲击/双重咆哮 (Double Strike/ Double Roll)###
- 二段攻击的雷电冲击和雷电咆哮
- 双重冲击读条3秒后，会释放雷电冲击，再过2秒后，会立即释放雷电咆哮
- 双重咆哮读条3秒后，会释放雷电咆哮，再过2秒后，会立即释放雷电冲击

###3.6 雷云暴风 (Cloudstorm)###
- Boss读条雷云暴风，同时在场地的(0,17.3)、(17.3,0)处或(0,-17.3)、(-17.3,0)处出现两颗雷云的预兆，4秒读条后，雷云会以自身为中心放置10米半径的圆形伤害区域，每隔2秒对进入该区域的玩家赋予<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" />，雷云会持续60秒。
> <img src="https://s1.ax1x.com/2020/10/12/02PxVU.png" width = "200" height = "200" /> <img src="https://s1.ax1x.com/2020/10/12/02PzaF.png" width = "200" height = "200" />
> 　　　　　雷云预兆　　　　　　　　　　　伤害区域

###3.7 回声召唤 (Echo Summon)
- Boss在场地外侧的0点、3点、6点、9点、1点半、4点半、7点半、10点半之中的5个位置召唤小怪回声，回声不可击杀，会使用充能(Charge)和高压充能(Hypercharge)技能。
- 回声召唤没有读条，但召唤的同时Boss会出现台词“现身吧……汹涌雷霆的回声们！”作为提示。
> <img src="https://s1.ax1x.com/2020/10/12/02iKGd.png" width = "220" height = "200" />
> 　在8个随机刷新点中召唤5个回声
####3.7.1 充能 (Charge)###
- 回声在出现5秒后，朝向Boss射出一条连线，该连线可被玩家截断。
- 连线出现6秒后进行判定，如果连线的是玩家，会赋予该玩家<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，如果连线的是Boss，会赋予Boss<img src="https://s1.ax1x.com/2020/10/12/02iZVO.png" width = "20" height = "25" />。
> <img src="https://s1.ax1x.com/2020/10/12/02iYdS.png" width = "220" height = "200" />
> 　　　　充能与截断连线
####3.7.2 高压充能 (Hypercharge)###
- 回声在出现11秒后，5个回声中的一个会准备发动高压充能，此时有特效提示。
- 准备发动的3秒后，某个回声会朝向Boss释放宽为12米，长可覆盖场地的直线范围伤害，被<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 反转后攻击范围会变为该直线范围的两侧，每侧的直线范围的宽度同为12，长度覆盖场地。
- 高压充能命中的范围内的玩家会受到150%血量的伤害，如果高压充能命中Boss，会赋予Boss<img src="https://s1.ax1x.com/2020/10/12/02Ps4H.png" width = "20" height = "25" />，因此该技能必须被奇数次的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 反转。
> <img src="https://s1.ax1x.com/2020/10/12/02iwzn.png" width = "220" height = "200"> <img src="https://s1.ax1x.com/2020/10/12/02iDs0.png" width = "220" height = "200">
<img src="https://s1.ax1x.com/2020/10/12/02iBMq.png" width = "200" height = "200">


>　　　　　高压充能提示　　　　　　　　初始范围的高压充能　　　　　　　反转后的高压充能
###3.8 雷暴 (Thunderstorm)###
- Boss读条雷暴，3秒读条结束后，对所有玩家所在的位置放置半径为5米的圆形范围攻击的预兆，预兆放置后不会再移动，预兆出现3秒后，每个预兆范围内的的玩家都会受到66%血量的伤害。每个范围的伤害独立结算。
- 被<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 后的范围是一个环形，其外圆半径10米，内圆半径5米。每个伤害范围也独立判定反转，即如果一个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 持有者进入多个雷暴范围，多个雷暴范围不会同时被反转，而是只有一个雷暴去消耗 ，剩下的雷暴会保持原范围命中该玩家。
- 如果正常处理雷暴，推荐所有玩家集合，缩小所有雷暴地覆盖范围。
如果需要通过雷暴消耗<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> ，做法见图解。
> <img src="https://s1.ax1x.com/2020/10/12/02g3ee.png" width = "200" height = "200">
<img src="https://s1.ax1x.com/2020/10/12/02gGod.png" width = "200" height = "200">

>通过雷暴消耗一个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，预兆出现前按图1所示站位，预兆出现后移动至<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 持有者的雷暴范围里
>
><img src="https://s1.ax1x.com/2020/10/12/02g8dH.png" width = "200" height = "200"> <img src="https://s1.ax1x.com/2020/10/12/02gRS0.png" width = "200" height = "200">

>通过雷暴消耗多个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，预兆出现后需要躲避预兆的玩家移动至<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 持有者的雷暴的重合范围里
### 3.9 雷枪召唤 (Lance Summon) ###
- Boss在出现台词“雷霆之枪将贯穿汝之胸膛！”提示的2秒后，在场地外侧的3、6、9、12点中随机一点召唤一个雷枪，此后每隔1.5秒以随机顺时针或逆时针的方向在每隔120度的场地外侧召唤两个雷枪。

- 雷枪在被召唤的5秒后以场地中心为方向发动无范围提示的、宽为34.6米、长覆盖整个场地的直线范围攻击，对范围内的玩家造成约900%血量的伤害。
被<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 反转后，变成场地两侧劣弓形的攻击范围。

- 同时也是个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 检测机制，要求玩家必须持有至少一个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，其解法见图。
><img src="https://s1.ax1x.com/2020/10/12/02hLLV.png" width = "200" height = "200"/>
>　　雷枪的初始攻击范围示意

> <img src="https://s1.ax1x.com/2020/10/12/02hXZT.png"  width = "200" height = "200"> 
<img src="https://s1.ax1x.com/2020/10/12/02hqs0.png"  width = "200" height = "200">
<img src="https://s1.ax1x.com/2020/10/12/02hjdU.png"  width = "200" height = "200"> <img src="https://s1.ax1x.com/2020/10/12/02hvoF.png" width = "200" height = "200"> 

> 处理雷枪的步骤示意，首先移动至和第一个雷枪垂直的整点方向的场地边缘，在第一个雷枪判定后跟随剩余雷枪的顺/逆时针出现方向移动至能躲避第三个雷枪攻击范围的位置，持有<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />  可以无视第二个雷枪的的攻击


##4. 时间轴##
该阶段战斗的时间轴如下：

时间轴|Boss本体|回声和雷枪|<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />持有情况
:---:|:---:|:---:|:---:
0000|战斗开始	
0006|变压电流（对3玩家）
0009|变压电流判定		||+3
0013|雷电冲击/雷电咆哮		
0016|雷电冲击/雷电咆哮判定||最多可以-3
0020|吸收	||要求0	
0024|雷光电涌		
0033|双重冲击/双重咆哮
0036|第一次冲击/咆哮判定
0038|第二次咆哮/冲击判定
0041|审判打击|
0045|审判打击判定||+1		
0046|跨步电压||可以-1，推荐-1			
0051|变压电流（对4玩家）	
0054|变压电流判定	||+4	
0057|雷云风暴	
0063||回声召唤
0066|雷暴
0068||充能连线		
0069|雷暴位置判定，预兆出现
0072|雷暴伤害判定||可以-0~-4，推荐-2
0074|		|连线判定，高压充能提示|所有接线成功+5	
0077|		|高压充能判定|正常处理此时-7
0078|吸收		||要求0
0082|	雷光电涌		
0091|	审判打击
0095|审判打击判定||+1		
0096|跨步电压||不能-1，换T处理		
0098|雷暴		
0101|	雷暴位置判定，预兆出现	
0102|双重冲击/双重咆哮
0104|雷暴伤害判定||	不能-1		
0105|第一次冲击/咆哮判定||不能-1	
0107|第二次冲击/咆哮判定|雷枪召唤|不能-1
0109|			|第一个雷枪出现
0110.5|			|第二个雷枪出现
0112|			|第三个雷枪出现
0114|			|第一个雷枪伤害判定
0115.5|			|第二个雷枪伤害判定|-1
0118|			|第三个雷枪伤害判定
##5.部分组合技处理方法##
由于现在职能操控远程输出职能2，以下以远程输出职能2的处理<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 的优先级说明为主，全队优先级后续补充。如果不需要知道处理原理只需知道处理方法，只看加粗部分即可。
###5.1 0013时，带有三个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />的雷电冲击/雷电咆哮处理###
* 之后马上会有吸收来检测0个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，因此需要确保雷电冲击/雷电咆哮消耗掉所有的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />。
* 通过简单推理可得，需要有1个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 离开雷电冲击/雷电咆哮的初始攻击范围，两个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 进入初始攻击范围，其余没有<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 的玩家也进入初始攻击范围。
* **此时远程输出职能2具有最高的离开初始攻击范围优先级，如果持有 <img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，则离开初始攻击范围，否则进入初始攻击范围。**
### 5.1 0041时，审判打击和跨步电压###
- 审判打击会赋予主坦克<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> ，为方便后续处理，审判打击时两个坦克不交换主坦克，因此该<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 会被跨步电压消耗，**全员需要来到主坦克一侧回避反转的跨步电压。**
- 虽然这个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 也可以想办法在后面消耗掉，但后续的变压电流也可能赋予<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 给主坦克造成<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" />，因此尽量避免。
###5.2 0063时，雷暴/回声召唤的组合技###
- 之前的变压电流和充能一共会给予玩家9个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，而玩家只有8个，必然会重复赋予<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 造成<img src="https://s1.ax1x.com/2020/10/12/02CjtH.png" width = "20" height = "25" />，因此需要通过雷暴消耗掉。同时，高压充能要求奇数个的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，所以通过雷暴消耗掉的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 应为2个（消耗4个会造成极小的安全范围，不推荐）。
* **连线出现后不着急接，先处理雷暴。此时远程输出职能2具有最低的消耗<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 优先级，因此和人群集合并远离要消耗<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 的玩家，等待雷暴预兆出现后移动至两个消耗<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 玩家的雷暴预兆的重合范围。由于场上的雷云伤害区域存在，集合地点根据雷云位置选择右方或者下方。**
* 雷暴判定后2秒充能连线会判定，**没有<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 的玩家要去截获5根充能连线，此时远程输出职能的截线优先级为从9点开始逆时针数的第一根线。**如果有任何意外情况导致截线后不是奇数个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，应当放弃一根连线，但会给后续增加治疗和输出压力。
* 连线判定后，同时某一个回声会准备使用高压充能，由于后续会有吸收来检测0个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，因此需要确保高压充能消耗掉所有的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />。
* 通过简单推理可得，高压充能的初始范围内的<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />  个数需要比初始范围外多一个，为方便近战输出，**远程输出职能2拥有高压充能最高的处理优先级：当发现近战输出职能和坦克少了<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 并且自己有一个的话，需要进入高压充能的初始范围，否则远离高压充能的初始范围。**
###5.3 回声召唤后到雷枪召唤###
* 雷枪召唤需要至少一个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 而这个阶段只有审判打击会给一个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" />，因此这个阶段的审判打击需要坦克职能交换主坦克，**同时全员不能够站在交换后的主坦克的一侧。**后续需要确保这个<img src="https://s1.ax1x.com/2020/10/12/02CaTg.png" width = "20" height = "25" /> 不被其他范围攻击消耗掉。
* 正常处理后续所有机制，雷枪的攻击由于某一侧会有雷云的伤害区域，所以**第一个雷枪出现后要来到没有雷云伤害区域的安全范围。**



