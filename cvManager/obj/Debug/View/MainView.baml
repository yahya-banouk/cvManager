   M S B A M L   `   `   `  ????D  @cvManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:cvManager.ViewcvManager.View  5   	   9!clr-namespace:cvManager.ViewModelcvManager.ViewModel  5   	       cvManager.View.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:cvManager.View     5   	   2view!clr-namespace:cvManager.ViewModel     5   	   X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     ? Title$  MainView??5
   	   $	??750??6   $
??1400??6'    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$
 None=?5   	   
??????  ? AllowsTransparency .  ? DataContext 5      '   !cvManager.ViewModel.MainViewModel  5   
    ? 	Resources 5       ?? DataType'   !cvManager.ViewModel.HomeViewModel   cvManager.View.HomeView,   &cvManager.ViewModel.CondidateViewModel"   cvManager.View.CondidateView/   )cvManager.ViewModel.AddCondidateViewModel%   cvManager.View.AddCondidateView??%?   (??       5      *, +)(?? 2     5      *, +)(?? d     5      *, +)?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      5      .??5   
   ??  ?? CornerRadius$ 10??6   $??2q?5       ??5#      ?? 5$       ?? 
StartPoint$	 0,0&?6&   	 ?? EndPoint$		 1,1&?67   .??5%      ?    winBorderColor1
 ? Color#
 [  6#    ? Offset$ 1Q?6L   ? 5&        winBorderColor2#
 [ 6#   $
 0.75Q?6L   ? 5'        winBorderColor3#
 [ 6#   $ 0Q?6L   5(      ._?5,      ?  ? ColumnDefinitions 5-      ?? 5/      $	??320 ?6'   ?? 51      $??* ?6'   .+?55      ?? $ 	10,0,0,10??6   $??0??56      ??57      ?? 58      $	 0,1&?6.   $	 1.3,0&?6?   .??59      ?   primaryBackColor1#
 [ 6+   $ 0Q?6V   ? 5:        primaryBackColor2#
 [ 6+   $ 1Q?6V   5;      ._?5=      ?? .+?5?      ??  ?? Orientation$ 
Horizontal=?6%   $??35??5@   !   $??
15,25,0,40q?5A   !   .+?5B      ?? $$??/Images/LOGOHIBAPOWER 2020.png??6$   ?? 5C      $!??Votre Partenaire EcoEnergie??6(     titleColor2#??[ 5D   $   $??20(?5E   $   $??	Monserrat)?5F   $   $??Medium"?5G   $   $??Center=?5H   $   $??10,0,0,0q?5I   $   5K      	? 5O        
menuButton#??[ 6&     color11
 ? Tag# [ 5P   "    d? 	IsChecked$
 TrueY?5Q   "   ??5R   "   ?? *ShowHomeViewCommand+.??5S      ?? $ 
Horizontal=?6)   .+?5T   "   !  FontAwesome.Sharp.IconImage  ?	  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]] 	  Icon$
 Home=?6/     menuButtonIcon#??[ 6;   ?? 5U   "   $??Accueil??6,    	 menuButtonText#??[	 6;   5X      5[      	? 5]      #??[ 6&    

 color7# [
 5^   "   ??5_   #   ?? *ShowCondidateViewCommand+.??5`      ?? $ 
Horizontal=?6)   .+?5a   "     $ 	UserGroup=?6/   #??[ 6@   ?? 5b   "   $??	Condidats??6,   #??[	 6=   5e      5h      	? 5j      #??[ 6&    
 color3# [ 5k   "   ??5l   &   ?? *ShowAddCondedateViewCommand+.??5m      ?? $ 
Horizontal=?6)   .+?5n   "     $ UserPlus=?6/   #??[ 6?   ?? 5o   "   $??Nouveau Condidat??6,   #??[	 6D   5r      5u      	? 5w      $y?	Collapsed=?6&   #??[ 6=     color13# [ 5x   "   .??5y      ?? $ 
Horizontal=?6)   .+?5z   "     $ Tools=?6/   #??[ 6<   ?? 5{   "   $??	Réglages??6,   #??[	 6<   5~      5?      	? 5?      #??[ 6&     color12# [ 5?   "   ??5?   &   ?? *LogoutCommand+.??5?      ?? $ 
Horizontal=?6)   .+?5?   "     $ RightFromBracket=?6/   #??[ 6G   ?? 5?   "   $??Se déconnecter??6,   #??[	 6B   5?      5?      5?      5?      ?? 5?      $ 	0,10,10,0??6   $??1??5?      ??5?      ?? 5?      $	 1,0&?6.   $	 0.5,1.3&?6?   .??5?      ? $
 #014B00??6'   $	 0.2Q?67   ? 5?      $
 #11003D??6'   $
 0.55Q?67   ? 5?      $
 #014B00??6'   $	 1.1Q?67   5?      ._?5?      ?  ? RowDefinitions 5?      ?? 5?      $??25 ?6,   ?? 5?      $??35 ?6,   ?? 5?      $??* ?6,   .+?5?      ?? -   5         ??Name$ pnlControlBar??5?   %   $??0??5?   !   $ 
Horizontal=?5?   !   $??RightToLeft=?5?   !   
?????? $??0,0,5,0q?5?   !   .+?5?      ?? -   5         ??Name$ btnClose??5?   %     ControlButton#??[ 5?   !    
 color4# [ 5?   !   .??5?   "     $ Xmark=?6/     controlButtonIcon#??[ 6<   5?      ?? 5?      -   5        $ btnMaximize??5?   %   #??[ 5?   !    
 color6# [ 5?   !   .??5?   "     $ Square=?6/   #??[ 6=   5?      ?? 5?      -   5        $ btnMinimize??5?   %   #??[ 5?   !    
 color8# [ 5?   !   .??5?   "     $ WindowMaximize=?6/   $??12??6E   #??[ 6P   5?      5?      ? 5      $??1??6    5     ?? 5  "   ?? 5  "   .+?5     ?? $??0??6)   $ 
Horizontal=?5	  %   $??Center=?5
  %   .+?5  "     $??20??5  1   $??20??5  1    	  
Foreground# [ 5  1   $??	35,0,10,0q?5  1    5  5   ?? *Icon+5  1   ?? 5  "   #??[ 5  (   $??16(?5  (   $??
Montserrat)?5  (   $??Medium"?5  (   $??Center=?5  (   ??5  ,   ?? *	Caption+5  (   5     ?? 5     $??1??6)   $ 
Horizontal=?5  %   $??RightToLeft=?5  %   $??Center=?5  %   $??0,0,10,0q?5  %   .+?5   "   ??   
iconButton#??[ 6)    
 color1# [ 5!  %   .??5"  &     $ 	AngleDown=?63     iconButtonIcon#??[ 6D   5$  #   ?? 5&  "   #??[ 5'  &   $??
Montserrat)?5(  &   $??12(?5)  &   $
??Left=?5*  &   $??Center=?5+  &   $??12??5,  &   $	??100??62   ??5&  ,   ?? * CurrentUserAccount.DisplayName+5,  2   A? 5.  "   $??35??6*   $??35??66    
 color2#??[ 5/  &   $??2??50  &   $??10,0,5,0q?51  &   ??52  &   ?? 53  *    ?? ImageSource$ /Images/user-icon.png??65    j? Stretch$
 None=?6Y    j? 
AlignmentX$ Center=?6h    j? 
AlignmentY$ Center=?6|   56  #   5G     5I     ?? 5N     $??2??5O  %   $??25q?5P  %   ??5N  )   ?? *CurrentChildView+5P  %   5T     5W     5Y     5\     5`     