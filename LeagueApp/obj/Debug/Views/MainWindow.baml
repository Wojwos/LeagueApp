   M S B A M L   `   `   `  ����D  @LeagueApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LeagueApp	LeagueApp  5   	   ;"clr-namespace:LeagueApp.ViewModelsLeagueApp.ViewModels  5   	   1clr-namespace:LeagueApp.ViewsLeagueApp.Views  5	   	       LeagueApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   #localclr-namespace:LeagueApp  5   	   3
viewModels"clr-namespace:LeagueApp.ViewModels  5   	   )viewsclr-namespace:LeagueApp.Views  5	   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)    � WindowStyle$
 None=�66   ���	#FF611B64 � 
ResizeMode$ NoResize=�6`    � WindowStartupLocation$ CenterScreen=�6v    � 	Resources 5       �� DataType.  (LeagueApp.ViewModels.MainWindowViewModel0  *LeagueApp.ViewModels.AccountStatsViewModel"   LeagueApp.Views.AccountStats � DataContext2  ,LeagueApp.ViewModels.PlayersRankingViewModel$   LeagueApp.Views.PlayersRanking��%.  (��       5,   3   *, +)(�� /     5-   5   *, +)(�� �     50   7   *, +)�� 5,   
   MainWindowTemplate��"  63   �� 5-   
   AccountStatsTemplate��"  65   .R�5.         6!   �� 5/      �� 50   
   PlayersRankingTemplate��"  67   .R�51         6#   �� 52      53      .��54      � .+�55   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $
��Left=�6F   .+�56      A� $��50��6   $��50��6"   ��57      �� 58       �� ImageSource 6!   �� *SummonerIconId+5:      �� 5;      $	��150��6   $��30��6$   $
��Bold"�60   $��20(�6B   ��6P   �� *SummonerName+�� 5<      $��50��6   $��30��6#   $
��Bold"�6/   $��20(�6A   ��6O   �� *SummonerLevel+�� 5=      $
��0 10q�6   $ 
Horizontal=�6'   $	��Top=�6@   $��Center=�6X   .+�5>      �� $	��400��6   $��30��6&   $��20(�62   ��6@   �� *SearchedSummonerName+.��6f   	 J� Effect	 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5@      
   Color$
 Black��6+      Opacity$	 0.5Q�69      ShadowDepth$ 2Q�6G      	Direction$	 270Q�6W   .��5A   &   5B      �� 5C      $��75��6   $��30��6&    �� Text 62   �� *Region+.@�5D      �� $
��EUW1��6#   �� 5E      $
��EUN1��6#   �� 5F      $	��NA1��6#   5G      �� 5H      $��75��6   $��Search��6$   ��65   �� *SearchPlayerCommand+5I      5J      �� 5K   
   $��Right=�6   $��Bottom=�61   $ 
Horizontal=�6L   $��	0,0,0,580q�6e   .+�5L      �� -   5        
������ 
������ .��5M      '  !MaterialDesignThemes.Wpf.PackIcon  
�������   Kind$ WindowMinimize=�6=   5N      �� 5O      -   5        
������ 
������ .��5P        
�������$ Close=�6=   5Q      5R      �� 5S   
   $ 
Horizontal=�6   $��0 50 0 0q�6.   .+�5T      � $	��250��6   $	��150��6   $	��Top=�6,    � RowDefinitions 5U      �� 5V      $��75 �6$   �� 5W      $��75 �6$    � ColumnDefinitions 5Y      �� 5Z      $��1* �6'   .+�5\      � $��0��6   .+�5]      �� 
������ $��0q�66   $��Account statistics��6J   $��SemiBold"�6g   $��25(�6}   ��6�   �� *AccountStatsCommand+5^      � 5_      $��1��6   .+�5`      �� 
������ $��0q�66   $��Player ranking��6J   $��SemiBold"�6c   $��25(�6y   ��6�   �� *PlayerRankingCommand+5a      5b      �� 5k      ���	#FF864489._�5l      �� $	��750��6!   ��6-   �� *CurrentViewModel+5m      5n      5o      5p      