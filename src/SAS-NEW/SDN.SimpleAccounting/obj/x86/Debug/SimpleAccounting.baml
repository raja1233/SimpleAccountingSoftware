   M S B A M L   `   `   `  ����O  KSDN.SimpleAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SDN.SimpleAccountingSDN.SimpleAccounting  5   	   T PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5   	   +    %SDN.SimpleAccounting.SimpleAccounting   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   	   4local"clr-namespace:SDN.SimpleAccounting 	    5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    5   	   n
 jMicrosoft.Practices.Prism.Interactivity, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \Microsoft.Practices.Prism, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35+prismhttp://www.codeplex.com/prism 
  5   	   ;region,clr-namespace:SDN.Common;assembly=SDN.Common 
  5   	   (  "MahApps.Metro.Controls.MetroWindow    ShowTitleBar  . )  #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . $	��768��5	      $
��1024��6      	TitleCaps .     TitleCharacterCasing$ Normal=�66      ShowCloseButton .     ShowMaxRestoreButton .     ShowMinButton .   � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�6.   
���   �$��0q�6Z   $
��Auto=�5   	   	   WindowTitleBrush
	 �   � 
   NonActiveWindowTitleBrush

 �   �$
��Auto=�5      ��. 
���   � � 	Resources 5         	converter��%   &	        �� 5   
   6'   5         LeftWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
      ShowSeparators .  $��	-8,0,10,1q�6:   $	��Top=�6N   .@�5      � -   5        $��grdTitle��5      $
��1024��6$   
�������$	��Top=�6G   y�6`   �� *IsHeaderRegionVisible+ �� 	Converter# [   � RowDefinitions 5      �� 5      $��40 �6$   62    � ColumnDefinitions 5      �� 5      $	��400 �6'   65   �� 5      $��* �6'   63   �� 5      $��25 �6'   64   �� 5      $��25 �6'   64   �� 5      $��25 �6'   64   �� 5      $��25 �6'   64   �� 5      $��25 �6'   64   �� 5       $��25 �6'   64   .+�5#      �� $
��Left=�6   $��Center=�67     
TitleStyle#���  6j   $��0��6�   $��0��6�   $��	10,0,0,10q�6�   ��6S   �� *Title+6�   �� 5$      $��1��6   $��0��6,   $	��499��69   6G   �� 5%      -   5         � Cursor$
 Hand��5%      $��0��6*   $��2��67    � ToolTip$ Refresh��6[   $��0,1,0,10q�6m   .��5&      ��  �� Orientation$ 
Horizontal=�6!   .+�5'      �� $��15��6$   $��15��5(      ��5)      ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask 5*      !� 5+   "    j� Stretch$
 Fill=�6.     appbar_refresh !� Visual# [ 6=   5-      5/      50      �� 51      -   5        $	��btn��51      $
 Hand��67   $��0��6E   $��3��6R   $ Open Screens��6c   $��0,1,0,10q�6z   .��52      �� $ 
Horizontal=�6!   .+�53      �� $��15��6$   $��15��54      ��55      ��  �� $ ButtonL�$ 
Foreground� 56      !� 57   "   $
 Fill=�6.     appbar_folder# [ 6=   59      5;      5?      �� 5@      -   5        $��	comboBox1��5@   �   $	��100��6r   $y�Hidden=�6~   $
 Hand��6�   $��0��6  $��3��6  $ Open Screens��6  $��
-70,1,0,10q�66   �� SelectedItem 6   �� *
ScreenName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *Items+$ PropertyChanged=�$ TwoWay=�5B      �� 5C      $
 Hand��6>   $��0��6M   $��4��6Z   $
 Home��6k   $��0,1,0,10q�6z   ��6   �� *HomeClickCommand+.��5D      �� $ 
Horizontal=�6!   .+�5E      �� $��15��6$   $��15��5F      ��5G      ��  �� $ ButtonL�$ 
Foreground� 5H      !� 5I   "   $
 Fill=�6.     appbar_home# [ 6=   5K      5M      5N      �� 5O      $
 Hand��6   $��0��6*   $��5��67   $
 Help��6G   $��0,1,0,10q�6V   .��5P      �� $ 
Horizontal=�6!   .+�5Q      �� $��15��6$   $��15��5R      ��5S      ��  �� $ ButtonL�$ 
Foreground� 5T      !� 5U   "   $
 Fill=�6.     appbar_question# [ 6=   5W      5Y      5Z      �� 5[      -   5        $
 Hand��5[      $��0��6*   $��6��67   $ Minimize��6H   $��0,1,0,10q�6}   .��5\      �� $ 
Horizontal=�6!   .+�5]      �� $��15��6$   $��15��5^      ��5_      ��  �� $ ButtonL�$ 
Foreground� 5`      !� 5a   "   $
 Fill=�6.     appbar_monitor_minus# [ 6=   5d      5f      5g      �� 5h      -   5        $
 Hand��5h      $��0��6*   $��7��67   $ Close��6H   $��0,1,0,10q�6w   .��5i      �� $ 
Horizontal=�6!   .+�5j      �� $��15��6$   $��15��5k      ��5l      ��  �� $ ButtonL�$ 
Foreground� 5m      !� 5n   "   $
 Fill=�6.     appbar_close# [ 6=   5p      5r      5s      5t      � 5u      -   5        $��	grdTitle1��5u      $
��1024��6%   
�������$	��Top=�6H   y�6a   �� *IsBlankHeaderRegionVisible+# [   5v      �� 5w      $��40 �6$   62    5y      �� 5z      6)   .+�5|      �� $��0q�6   $��0��6,   $
��1024��69   6H   5}      5~      .��5�      ]� .+�5�   
   �� $��0 0 0 0q�6   $
��Left=�6+   
�������$	��Top=�6Y   $
��1024��6n   ._�5�      �� $
��Left=�6   $��40��69   $
��1024��6E     SDN.Common.RegionNames   MenuBarRegion5  /Microsoft.Practices.Prism.Regions.RegionManager   
RegionName# Z 5�      y�5�   S   �� *IsMenuRegionVisible+# [  5�      5�      �� 5�   
   $
��Left=�6   
�������$	��Top=�6?   $
��1024��6T   ._�5�      �� $
��Left=�6   $��40��69   $
��1024��6E      SubMenuBarRegion# Z 5�      y�5�   S   �� *IsSubMenuRegionVisible+# [  5�      5�      �� 5�   
   $
��Left=�6   
�������$��Bottom=�6?   $
��1024��6W   ._�5�      �� $
��Left=�6   $��30��68   $��Bottom=�6D   $
��1024��6]       FooterRegion# Z  6�   y�6k   �� *IsFooterRegionVisible+# [  6�   5�      �� 5�   
   $
��Left=�6   
�������._�5�      �� $
��Left=�6   $
��Auto��69   $
��1024��6G   !   
MainRegion# Z! 6U   5�      5�      5�      