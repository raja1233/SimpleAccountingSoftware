   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SDN.Settings.ViewsSDN.Settings.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      O6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
      %    SDN.Settings.Views.CategoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SDN.Settings.Views     5      <ctr,clr-namespace:SDN.Common;assembly=SDN.Common     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5	      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
      $
��Auto��5      $
��Auto��6     � 	Resources  5      0  *SDN.Common.Converter.SelectedItemConvertor   SelectedItemToItemsSource.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter  ContentGrid �� CornerRadius �� 
TargetType �� Property �� Value � RowDefinitions � ColumnDefinitions �� BindingGroupName �� UpdateSourceTrigger	 �� 	MaxLength
 �� TextWrapping �� Mode ��Name d� 	IsChecked��%�  &	        &	      &	 &       5   
   6(     5   
   6&   �� 5   
   .R�5      �� 
������ 
���   �$��1q�6B   $ 0��5      ._�5      � $��10q�6     5      ���� 5      '��       " ��6    .�5       ��  � ��$ 0,0,0,0q�67   �� 5!       � ��$ 20��67   �� 5"       � ��
 �   �6<   5#      5$       5%      �� 5&      �� 5'      �� 5(      6*   �� 5)      6*    5+      �� 5,      $��80 �6+   �� 5-      $��5* �6+   .+�5/      �� $��Category��6    $��0��60   $��0��6=   �� 50      $��1��6!   $��0��6.   ��6?   �� *ContentType+51      �� 52      {�.  $��7,0,5,0q�6�   $��1��53      $��0��6.   ��52   0   �� *CategoryName+$ Group1��$ PropertyChanged=�53   .   ]� 54      $��1��6    $��1��60   .+�55      �� 
���  ��$��*��65   �� 56      $��txtContentName��6"   -   5        $
��Left=�56   8   $��3,2,7,0q�57   ?   $	��200��6s   $
��Auto��6�   $		 200��58   9   $

 Wrap=�6I   $	��200��6]   $	��300��6l   $��25��6|   ��56   S   �� *ContentName+$ Group1��$ TwoWay=�$ PropertyChanged=�.��58   �   59      5:      �� 5;      $��Set Default��6    $��2��63   $��0��6@   6R   �� 5<      $ chksetDefault��6q   $��2��6�   $��1��6�   $��7,2,0,0q�6�    6   �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�6�   5=      5>      5?      5A      .��5B      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5C   
   � $��0,10,0,0q�6    5D      �� 5F      $��0.75* �6    �� 5G      $��4* �6    �� 5H      $��5* �6    �� 5I      $��0.75* �6     5K      �� 5L      $
��auto �6#   64   �� 5M      $
��auto �6#   62   �� 5N      $��4* �6#   61   .+�5T      �� $��Italic$�6   $��0��6+   $��0��68   $��2��6H   $@��:Click on a Category Name and add or edit Category Contents��6\   $��10,0,0,0q�5U      
�������$
��Left=�60   $	��Top=�6K   6e   � 5W      $��1��6   $��0��6    $��10,0,0,0q�60    5X      �� 5Y      .+�5_      ��  �� Orientation$ 
Horizontal=�6   .+�5`      � $	��300��6   $	��400��6)   ��68   �� *CategoryHeight+.+�5a      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5a   #   $��0��6d      GridLinesVisibility$	 All=�5b   P      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�5d      "   VerticalScrollBarVisibility$ Disabled=�6C     BackHeaderStyle20   ColumnHeaderStyle# [ 5e         HeadersVisibility$	 All=�6R   $��0,0,0,0q�6j   ��5a   <   �� *BackGroundLines+��5b      ��  �� ElementName$	 dg1�� �� Path$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�   Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g   "   ,  &System.Windows.Controls.DataGridColumn   Header$  ��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 298 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Col0+6g   5n        5o      -   5        $	 dg1��5o   f   $	 All=�6#   $��0��6=   
������    
IsReadOnly . $��1q�6�   $	��300��6�   $	��400��6�   $	��200��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5p   E       CanUserAddRows  .  !   CanUserDeleteRows! .    HeaderStyle20# [ 5q   z   " �� SelectedValuePath$" ID��5r      #   CanUserSortColumns# .  $   CanUserResizeColumns$ .  %   CanUserResizeRows% .   .  
���   ���5o   �   �� *CategoryHeight+��5p      �� $ Category�& �� SelectedItem& 5q      �� *SelectedCategory+$ TwoWay=�$ PropertyChanged=� 5t        5v   "   $	 298 65   '   MaxWidth$	' 400Q�6A   $ Category Name��6P    6g   �� $ CategoryName�5w   #     5y      )  #System.Windows.Controls.DataGridRow( �� 	Resources) �� Color��%�   '        �� 5z   "   "  6(   ( 5{   &   ���� 5|   *   $) Black��6}   (��       6:   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6}   5}   '   5~   #   5      .	  (System.Windows.Interactivity.Interaction* 	  Triggers* 5�      /
  )System.Windows.Interactivity.EventTrigger
  5�   "   + 
  	EventName$+ SelectionChanged��61   .  (System.Windows.Interactivity.TriggerBase,   Actions., 5�   &   6  0System.Windows.Interactivity.InvokeCommandAction  -   Command- 6<   �� *SelectChangedCommand+5�   #   .   	CellStyle. 5�      �� 5�   "   *  $System.Windows.Controls.DataGridCell"  6(   / �� Triggers/ 5�   &   P� 5�   *   0 P� Property0 �@ 
IsSelected1 P� Value1 . . �5�   .   ��  � ��
 �   �5�   2   �� 5�   .    � ��
 �   �5�   5   �� 5�   .    � ��
 �����5�   2   5�   +   5�   #   2   RowStyle2 5�      �� 5�   "   "  6(   / 5�   &   P� 5�   *   0 �@ 
IsSelected1 . . �5�   .   ��  � ��
 �   �5�   2   �� 5�   .    � ��
 �   �5�   5   �� 5�   .    � ��
 �����5�   2   5�   +   5�   #   5�      5�      5�      5�      � 5�      $��5,0,5,0q�6   $��1��6%   $��1��65    5�      �� 5�      .+�5�      �� .+�5�      �� $ 
Horizontal=�6!   .+�5�      � .+�5�        -   5        $ CustomGridLinesCatContent��5�   '   $��0��6r   $	 All=�5�   _   
 �����
 ����� .  $ Hidden=�5�      $ Disabled=�6C   # [ 5�      $	 All=�6R   $��0 0 0 0q�6j   ��5�   J   �� *BackGroundLines+��5�      �� $ grdCategoryContent��$ ActualHeight���6{   �� $ grdCategoryContent��$ ActualWidth� 5�   "     5�   &   $  ��69   $ 50 6\    6C   �� *Col0+6i     5�   &   $  ��69   $ 1 6]   3   
Visibility$3 Hidden=�6g    6C   �� *Col1+6}     5�   "   $  ��65   $	 297 6Y    6?   �� *Col2+6g     5�   &   $  ��69   $ 1 6]   $3 Hidden=�6g    6C   �� *Col3+6}   5�        5�      -   5        $��grdCategoryContent��5�      $	 All=�5�   '   $��0��6A   
������ # [ 6j   $��1q�6�   # .  
���   �  .  ! .   .   . $" 	ContentID��5�   �   $	��350��5�      $ . % .  ��5�   �   �� *SelectedContent+$ TwoWay=�$ PropertyChanged=�& 5�   C   �� *SelectContent+$ TwoWay=�$ PropertyChanged=�4 �� SelectedIndex4 5�   \   �� *SelectedIndex+��5�      �� *CategoryHeight+ 5�   "   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   $ Default��6>   $ 50 6O   5   CellTemplate5 5�   *   �� 5�   .   .R�5�   2   	� 6 	� 	GroupName$6 
grpDefault��6?   $��Center=�6X   $��Center=�6u   $��0 0 0 0q�6�   {�.   5�       �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�5�   3   5�   /   5�   '     5�   &   $  ��69   $3 Hidden=�6_   $ 1 6s    6C   �� $ ID�5�   '     5�   &   $	 297 69   $ Category Contents��6E   7   
IsReadOnly7 .  6`   �� $ ContentName�8   ElementStyle8 5�   *   �� 5�   .   " ��64   .�5�   2   ��  � ��$
 Wrap=�6[   5�   /   5�   '     5�   &   $ 1 69   $  ��6C   $3 Hidden=�6M    6a   �� *
Predefined+6�     5�   "   ��%�   '        �� 5�   &   "  6,   ( 5�   *   ���� 5�   .   $) black��6�   (��       6>   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6�   5�   +   5�   '   5�   #   * 5�   "   
  5�   &   $+ SelectionChanged��65   ., 5�   *     - 6@   �� *SelectContentChangedCommand+5�   '   . 5�   "   �� 5�   &   "  6,   / 5�   *   P� 5�   .   0 �@ 
IsSelected1 . . �5�   2   ��  � ��
 �   �5�   2   �� 5�   2    � ��
 �   �5�   5   �� 5�   2    � ��
 �����5�   2   5�   /   5�   '   2 5�   "   �� 5�   &   "  6,   / 5   *   P� 5  .   0 �@ 
IsSelected1 . . �5  2   ��  � ��
 �   �5  2   �� 5  2    � ��
 �   �5  5   �� 5  2    � ��
 �����5  2   5
  /   5  '   5     5     5     5     5     �� 5     -   5        $��ContentsItemControl��5     $��2��5     $��1��6+   #��[ 5     $	��Top=�5     $
��Left=�6/   9 � BindingGroup9 5     �� *UpdateBindingGroup+$ TwoWay=���5     �� *SelectedCategoryContent+: �� 	Converter#: [  5  /   � 5     $��2��6   $��0��6    $��10,0,0,0q�60   $��Bottom=�6B    5     �� 5     .+�5"     �� .+�5#     �� $ 
Horizontal=�6!   .+�5&       -   5        $	 dg2��5&  j   $	 All=�6#   $��2��6=   
������  . $��1q�6�   $	��300��6�   $	��400��6�   $
 TrueY�5'  G     .  ! .  $" ID��5)     # .  $ .  % .  $	 Row=�5*      .  
���   ���5'     �� $ 
PSCategory�& 5(     �� *SelectedPSCategory+$ TwoWay=�$ PropertyChanged=� 5+       5-  "   $	 297 65   $	' 297Q�6A   $ Category Name��6P    6g   �� $ CategoryName�5/  #     52     ��%�   '        �� 53  "   "  6(   ( 54  &   ���� 55  *   $) Black��6}   (��       6:   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6}   56  '   57  #   58     * 59     
  5:  "   $+ SelectionChanged��61   ., 5;  &     - 6<   �� *SelectPSChangedCommand+5<  #   . 5>     �� 5?  "   "  6(   / 5@  &   P� 5A  *   0 �@ 
IsSelected1 . . �5C  .   ��  � ��
 �   �5D  2   �� 5E  .    � ��
 �   �5F  5   �� 5G  .    � ��
 �����5H  2   5J  +   5L  #   2 5N     �� 5O  "   "  6(   / 5P  &   P� 5Q  *   0 �@ 
IsSelected1 . . �5S  .   ��  � ��
 �   �5T  2   �� 5U  .    � ��
 �   �5V  5   �� 5W  .    � ��
 �����5X  2   5Z  +   5\  #   5^     5`     5a     5c     � 5e     $��5,0,5,0q�6   $��1��6%   $��2��65   $��Bottom=�6B    5f     �� 5g     �� 5h     .+�5j     �� .+�5k     �� $ 
Horizontal=�6!   .+�5l     �� ; �� AcceptsReturn; . $	��350��6�   $	��280��6�   $	��202��6�   $

 Wrap=�6�   $		 500��6�   ��67   �� *SelectedPSContent+$ TwoWay=�$ PropertyChanged=�6�   5m     5n     5o     �� 5q     $
��Bold"�6S   $��	5,190,0,0q�6e   
���  ��$
��Left=�5r     $��2��67   $��1��6G   $	��Top=�6T   $��3��5s     ��5q     �� *Error+$ PropertyChanged=�5s  +   ]� 5u     $��0��6   $��1��6&   $��Right=�67   $��Center=�6S   $��0,0,0,5q�6n   .+�5v     �� -   5        $��	btnDelete��5v  M   $��Delete��6     ButtonStyle#���  6^   ��6+   �� *DeleteCommand+5w  !   �� 5y     -	   5        $��btnNew��5y  *   $	��New��6   $��10,0,6,0q�69   #���  6K   ��5z     �� *NewRowCommand+6g   �� 5|     -
   5        $��btnSave1��5|  +   $
��Save��6   $��10,0,6,0q�6<   #���  6N   ��5}     �� *SaveRowCommand+5~     � 5�     $��3��6   $��2��6    $��	0 0 10 10q�60   $��Right=�6C    5�     .+�5�     ]� .+�5�     �� -   5        $��btnOk��5�  _   $��0 0 0 0q�6   $��Close��6.   #���  5�     $��Right=�67   ��5�  >   �� *CloseCommand+5�  V   5�     5�     5�     5�     5�     