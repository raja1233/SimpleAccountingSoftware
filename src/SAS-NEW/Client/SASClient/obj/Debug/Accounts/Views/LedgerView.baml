   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.Accounts.ViewsSASClient.Accounts.Views  5      ;"clr-namespace:SASClient.ConvertersSASClient.Converters  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
      )    #SASClient.Accounts.Views.LedgerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.Accounts.Views     5      8	converter"clr-namespace:SASClient.Converters     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5	      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
      $�� 1024��5      .��5      �   � 	Resources  5   
   9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%+  &	        &	      &	 &     &	 �     &	 �     &	 �       5      65     5      6H   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��70 �6   6*   �� 5       $
��auto �6   6,   �� 5!      6    � ColumnDefinitions 5#   
   �� 5$      6!   �� 5%      6!   �� 5&      6!   .+�5(   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6/   $��5��6<   $��8,7,5,10q�6P   .+�5)      	�  d� 	IsChecked$
 TrueY�6   	 	� 	GroupName$	 grpAccountsDetailsList��6+   $	��All��6N     TabMenuButtonStyle#���  6]   $��0��6�   $��10,0,0,0q�6�   -  'System.Windows.Input.KeyboardNavigation
   AcceptsReturn
 . ��5*   ;   �� *FilterAccountDetailsListClick+��6m   ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$ Content�	� 5+      $	 grpAccountsDetailsList��6   $��Sales��6>   #���  6O   $��1��6}   $��10,0,0,0q�6�   
 . ��5,   =   �� *FilterAccountDetailsListClick+��6o   ��  �� $
 Self=�$ Content�	� 5-      $	 grpAccountsDetailsList��6   $��	Purchases��6?   #���  6T   $��2��6�   $��10,0,0,0q�6�   
 . ��5.   =   �� *FilterAccountDetailsListClick+��6o   ��  �� $
 Self=�$ Content�	� 5/      $	 grpAccountsDetailsList��6   $��Receipts��6>   #���  6R   $��3��6�   $��10,0,0,0q�6�   
 . ��50   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$ Content�	� 51      $	 grpAccountsDetailsList��6   $��Payments��6>   #���  6R   $��4��6�   $��10,0,0,0q�6�   
 . ��52   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$ Content�	� 53      $	 grpAccountsDetailsList��6   $��Stock��6>   #���  6O   $��5��6}   $��10,0,0,0q�6�   
 . ��54   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$ Content�55      �� 56   
   $ 
Horizontal=�6   $��0��6.   $��4��6>   $��1��6R   $��10,5,0,5q�6_   .+�57      	� -   5         	�Name$ radShowAllYes��57      $��0 2 10 2q�6U   $	 radSelectionparameter��6i   $��6��6�   $
��Left=�6�   ��61   �� *ShowAllCommand+ 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��58      ]� .+�59      �� $��	Show All ��6!   64   �� 5:      $��2,1,2,1q�6;   ��6!   �� *
AllCount+6N   �� 5;      $�� ��6!   6+   5<      5=      � 5>      $	��300��6   $	��300��6$   $��30 0 0 0q�63   $	��306��6E    5?      �� 5@      $
��.25* �6'   66   �� 5A      6)   �� 5B      6)   �� 5C      6)    5E      �� 5F      $��30 �6$   62   �� 5G      6&   .+�5I      	� -   5        $ radyearmonthYes��5I   ;   $��0��6   $��0��6+   $	 radSelectionparameter��6T   $��0 0 5 0q�6v   ��5J      �� *YearQuarterSelectedCommand+ 6G   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5K      $��0��6   $��1��6)   $��Center=�69   $��Center=�6V   $
��Year��6q   6   �� 5L      $��0��6   $��2��6)   $��Center=�69   $��Center=�6V   $��Quater��6q   6�   �� 5M      $��0��6   $��3��6)   $��Center=�69   $��Center=�6V   $��Month��6q   6�   �� 5N      -   5        $��cmbYearSearch��5P   I   
���   �$��1��5N   /   $��1��6<    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5P       �� SelectedValuePath$
 Year��60   {�5N   L   �� *EnableYearDropDown+��5O      �� *	YearRange+ �� SelectedValue 5Q      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6w   �� 5R      -   5        $��cmbQuarterSearch��5W   J   
���   �$��1��5R   /   $��2��6<    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5W      $ ID��63   {�5R   L   �� *EnableQuarterDropDown+ w� TextPath 5U      �� *	Quarter+��5V      �� *QuarterList+ 5X      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5Y      -   5        $��cmbMonthSearch��5[   H   
���   �$��1��5Y   /   $��3��6<    . $ Month��5[      $ ID��61   {�5Y   L   �� *EnableMonthDropDown+��5Z      �� *	MonthList+ 5\      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5]      $��1��6   $��0��6)   #��[ 66   6]   �� 5^      $��1��6   $��1��6)   #��[ 66   6]   �� 5_      $��2��6   $��0��6)   #��[ 66   6]   �� 5`      $��2��6   $��1��6)   #��[ 66   6]   �� 5a      $��3��6   $��0��6)   #��[ 66   6]   �� 5b      $��3��6   $��1��6)   #��[ 66   6]   5c      � 5d      $	��300��6   $	��300��6#   $��30,0,0,0q�62    5e      �� 5f      6&   �� 5g      6&    5i      �� 5j      $
��.30* �6'   66   �� 5k      6)   �� 5l      6)   .+�5n      	� $��0��6   $��0��6+   $��
20 0  5 0 q�6;   $	 radSelectionparameter��6O   ��5o      �� *CalendarSelectionCommand+ 6J   �� *StartEndDateTrue+$ Group1��$ PropertyChanged=�6�   �� 5p      $��0��6   $��1��6)   $��
Start Date��69   6M   �� 5q      $��1��6   $��1��6)   $��End Date��69   6K   (  "System.Windows.Controls.DatePicker  5r      -   5        $
��Left=�5r   D   $	��150��6_   $	��150��6n   $��	-60 0 5 5q�6}   $��0��6�   $��2��5t      {�5r      �� *StartEndDateTrue+   SelectedDate 5t   -   �� *SelectedSearchStartDate+  5v      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� AncestorType��%�  '        7  �� 5w      "  6    .�5x      ��  � �� 5y   "   �� 5z   &   .R�5{   *   �� $ PART_TextBox��62    . $��0q�6Z   $��Stretch=�6n   $��Stretch=�6�   #���  6�   .��6�   ��5|   .   `� 5}   2   8   .1�5~   6   �� $ SelectedDate�6>   �� 5   6   $ 
DateFormat�6>   6R   �� 5�   6   $) #DataContext.SelectedSearchStartDate�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�        5�      -   5        $
��Left=�5�   E   $	��150��6`   $	��150��6o   $��	-60 0 5 5q�6~   $��1��5�   �   $��2��6�   {�5�      �� *EnableEndDropDown+   DisplayDateStart 5�   h   �� *EndDateValidation+ 6�   �� *SelectedSearchEndDate+  5�      ��%�  '        7  �� 5�      "  6    .�5�      ��  � �� 5�   "   �� 5�   &   .R�5�   *   �� $ PART_TextBox��62    . $��0q�6Z   $��Stretch=�6n   $��Stretch=�6�   #���  6�   .��6�   ��5�   .   `� 5�   2   8   .1�5�   6   �� $ SelectedDate�6>   �� 5�   6   $ 
DateFormat�6>   6R   �� 5�   6   $' !DataContext.SelectedSearchEndDate�6>    5�   A   �� "  5�   3   .��5�   <   5�   +   5�   '   5�      5�      5�      5�      5�      ]� 5�      $��0��6   $��3��6%   $��-5 0 0 0q�65   $��2��6G   .+�5�      �� $!��Select a Start and End date��6   
�������$��Italic$�6Q   6g   5�      5�      �� 5�   
   $ Vertical=�6   $��2��6,   $��4��6:   $��	0 10 20 0q�6N   $
��1000��6a   .+�5�      �  5�      �� 5�      $
��977* �6'   .+�5�      &   System.Windows.Controls.DataGrid  -   5           Name$  CustomGridLines��5�      $��0��6]   !   GridLinesVisibility$	! All=�5�   P   "   HorizontalGridLinesBrush
" �����#   VerticalGridLinesBrush
# �����$   AutoGenerateColumns$ .  $%   HorizontalScrollBarVisibility$% Hidden=�5�      "&   VerticalScrollBarVisibility$& Disabled=�6C     BackHeaderStyle20'   ColumnHeaderStyle#' [ 5�      (   HeadersVisibility$	( All=�6R   $��8,0,0,0q�6j   ��5�   5   �� *BackGroundLines+��5�      �� ) �� ElementName$	) dg1��$ ActualHeight���6l   �� $	) dg1��$ ActualWidth�*   Columns* 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn+   Header$+  ��6-   ,   Width5	  /System.Windows.Controls.DataGridLengthConverter$	, 160	 6Q   1
  +System.Windows.Controls.DataGridBoundColumn- 
  Binding- 67   �� *Col0+6_     5�      $+  ��6-   $	, 150	 6Q   - 67   �� *Col1+6_     5�      $+  ��6-   $	, 260	 6Q   - 67   �� *Col2+6_     5�      $+  ��6-   $	, 200	 6Q   - 67   �� *Col3+6_     5�      $+  ��6-   $	, 200	 6Q   - 67   �� *Col4+6_   5�        5�      -	   5        $	  dg1��5�      
������  . $��Visible=�5�   u   .   SelectionUnit$
. Cell=�5�   R    	 HeaderStyle20#' [	 5�      $	! All=�6P   $��1q�6k   /   CanUserAddRows/ .  $��10,0,2,0q�5�      0   CanUserSortColumns0 .  1   CanUserDeleteRows1 .  2   SelectionMode$2 Single=�6c   $	��Top=�6z   $ .  ��5�   4   �� *LedgerGridHeight+3   CurrentCell3 5�      �� *
CellInfo+$ OneWayToSource=���5�   �   �� *
LedgerList+$ TwoWay=�$ PropertyChanged=�* 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -
   5        TransactionDate��4   MinWidth$	4 200Q�5�   J   5   MaxWidth$	5 160Q�6Y   $
+ Date��6h   $
, Auto	 6w   6   HeaderTemplate6 5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   6>    5�   *   �� 5�   .   ��6?   �� $) TransactionDate��$ ActualWidth�.+�5�   *   ]� $��0��64   $��0��6A   .+�5�   .   �� #��z��68   5�   /   5�   +   5�   '   5�   #   7   CellTemplate7 5�      �� 5�   "   .R�5�   &   �� ��60   �� *TransactionDate+5�   *   5�   #   5�        5�      -   5        TransactionNumber��$	, 247	 5�   L   $	5 150Q�6X   $	4 247Q�6g   $+ Transaction No.��6w   6 5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   6>    5�   *   �� 5�   .   ��6?   �� $) TransactionNo��$ ActualWidth�.+�5�   *   ]� $��0��64   $��0��6A   .+�5�   .   �� #��z��68   5�   /   5�   +   5�   '   5�   #   7 5�      �� 5�   "   .R�5�   &   �� ��60   �� *TransactionNo+5�   *   5   #   5       5     -   5        AccountName��$	4 160Q�5  F   $	5 260Q�6U   $+ Account Name��6d   $
, Auto	 6{   6 5     �� 5  "   .R�5  &   �  5  *   �� 5	  .   6>    5  *   �� 5  .   ��6?   �� $) AccountName��$ ActualWidth�.+�5  *   ]� $��0��64   $��0��6A   $
��Left=�6Q   .+�5  .   �� #��z��68   $
��Left=�6Y   5  /   5  +   5  '   5  #   7 5     �� 5  "   .R�5  &   �� $
��Left=�60   �� 5  &   $	��100��60   $
��Left=�6\   8 �� TextAlignment$
8 Left=�6w   ��6?   �� *AccountName+6�   5     5   #   5"       5#     -   5        	Debit��$	4 180Q�5#  @   $	5 200Q�6O   $+ Debit��6^   $
, Auto	 6n   6 5%     �� 5&  "   .R�5'  &   �  5(  *   �� 5)  .   6>    5,  *   �� 5-  .   ��6?   �� $) Debit��$ ActualWidth�.+�5/  *   ]� $��0��64   $��0��6A   .+�50  .   �� #��z��68   $��Right=�6Y   51  /   55  +   57  '   58  #   7 5:     �� 5;  "   .R�5<  &   �� $��Right=�6G   ��60   �� *Debit+5=  '   5>  #   5@       5A     -   5        
Credit��$	4 179Q�5A  A   $	5 200Q�6P   $+ Credit��6_   6 5C     �� 5D  "   .R�5E  &   �  5F  *   �� 5G  .   6>    5J  *   �� 5K  .   ��6?   �� $) Credit��$ ActualWidth�.+�5M  *   ]� $��0��64   $��0��6A   $��Right=�6Q   .+�5N  .   �� #��z��68   $��Right=�6Y   5O  /   5S  +   5U  '   5V  #   7 5X     �� 5Y  "   .R�5Z  &   �� $��Right=�6I   $8 Right=�6e   ��61   �� *Credit+5[  '   5\  #   5^       5a     )  #System.Windows.Controls.DataGridRow9 �� 	Resources��%�   '        �� 5b     "  6   9 5c     ���� 5d     $ Black��6m   (��       6*   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6m   5e     5f     5g     .  (System.Windows.Interactivity.Interaction:   Triggers: 5i     /  )System.Windows.Interactivity.EventTrigger  5j     ;   	EventName$; SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase<   Actions.< 5k     6  0System.Windows.Interactivity.InvokeCommandAction  =   Command= 6,   �� *SelectChangedCommand+5l     >   	CellStyle> 5n     �� 5o     *  $System.Windows.Controls.DataGridCell"  6    ? �� Triggers? 5p     P� 5q  "   @ P� Property@ �@ 
IsSelectedA P� ValueA . . �5s  &   ��  � ��
 �   �5t  2   �� 5u  &    � ��
 �   �5v  5   �� 5w  &    � ��
 �����5x  2   5z  #   5|     B   RowStyleB 5~     �� 5     "  6    ? 5�     P� 5�  "   @ �@ 
IsSelectedA . . �5�  &   ��  � ��
 �   �5�  2   �� 5�  &    � ��
 �   �5�  5   �� 5�  &    � ��
 �����5�  2   5�  #   5�     5�     5�     5�     �� 5�  
   $��3��6   $��0��6"   $��3��62   $ 
Horizontal=�6F   $��Bottom=�6_   $��20��6z   .+�5�     �� $��10 -10 10 0q�6   $��  Amounts are in��6/   $��Italic$�6G   
�������6n   �� 5�     $��10 -10 10 0q�66   $��Italic$�6L   
���������6   �� *CurrencyName+6s   �� 5�     $��Close��6   $��3��6%   $��3��62   $��Right=�6B   $��770,-8,10,3q�6^    
 ButtonStyle#��� 
 6t   $	��New��6�   $��Bottom=�6�   ��6�   �� *CloseCommand+6�   5�     5�     5�     