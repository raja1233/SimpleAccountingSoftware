   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.CashBank.ViewsSASClient.CashBank.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      4    .SASClient.CashBank.Views.TransferMoneyListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.CashBank.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      $
��1024��5
      $
��Left=�6   
�������.��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%+  &	        &	      &	 &     &	 �     &	 �     &	 �       5      69     5      6H   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��30 �6    6.   �� 5      $��30 �6    6.   �� 5      $��30 �6    6.   �� 5!      $
��Auto �6    60   �� 5"      $��40 �6    6.    � ColumnDefinitions 5$      �� 5%      $	��256 �6#   61   �� 5&      $	��256 �6#   61   �� 5'      $	��256 �6#   61   �� 5(      $	��256 �6#   61   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��4��6B   $��0��6V   $��
10,15,0,10q�6c   $��3��6w   .+�5+      	� -   5         	�Name$ radShowAllYes��5+      $��0 2 10 2q�6Y   	 	� 	GroupName$	 radSelectionparameter��6m   $��14��6�   $
��Left=�6�   ��65   �� *ShowAllCommand+
 d� 	IsChecked
 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��5,      ]� .+�5-      �� $��	Show All ��6%   68   �� 5/      $�� ��6%   6/   50      51      ]� 5:      $��0��6   $��4��6(   $��2��6<   $��1��6M   $	��600��5;      $	��600��6(   $
��Left=�67   $��10 0 0 0q�6R   .+�5<      � $	��300��6   $	��300��6(    5=      �� 5>      $
��.25* �6+   6:   �� 5?      6-   �� 5@      6-   �� 5A      6-    5C      �� 5D      6*   �� 5E      6*   .+�5G      	� -   5        $ radyearmonthYes��5G   ?   $��0��6"   $��0��6/   $	 radSelectionparameter��6X   $��0 0 5 0q�6z   ��5H      �� *YearQuarterSelectedCommand+
 6G   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5I      $��0��6    $��1��6-   $��Center=�6=   $��Center=�6Z   $
��Year��6u   6�   �� 5J      $��0��6    $��2��6-   $��Center=�6=   $��Center=�6Z   $��Quater��6u   6�   �� 5K      $��0��6    $��3��6-   $��Center=�6=   $��Center=�6Z   $��Month��6u   6�   �� 5L      -   5        $��cmbYearSearch��5N   I   
���   �$��1��5L   3   $��1��6@    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5N       �� SelectedValuePath$
 Year��60   {�5L   P   �� *EnableYearDropDown+��5M      �� *	YearRange+ �� SelectedValue 5O      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6w   �� 5P      -   5        $��cmbQuarterSearch��5U   J   
���   �$��1��5P   3   $��2��6@    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5U      $ ID��63   {�5P   P   �� *EnableQuarterDropDown+ w� TextPath 5S      �� *	Quarter+��5T      �� *QuarterList+ 5V      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5W      -   5        $��cmbMonthSearch��5Y   H   
���   �$��1��5W   3   $��3��6@    . $ Month��5Y      $ ID��61   {�5W   P   �� *EnableMonthDropDown+��5X      �� *	MonthList+ 5Z      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5[      $��1��6   $��0��6-   #��[ 6:   6a   �� 5\      $��1��6   $��1��6-   #��[ 6:   6a   �� 5]      $��2��6   $��0��6-   #��[ 6:   6a   �� 5^      $��2��6   $��1��6-   #��[ 6:   6a   �� 5_      $��3��6   $��0��6-   #��[ 6:   6a   �� 5`      $��3��6   $��1��6-   #��[ 6:   6a   5a      � 5b      $	��300��6   $	��300��6'   $��10,0,0,0q�66    5c      �� 5d      6*   �� 5e      6*    5g      �� 5h      $
��.30* �6+   6:   �� 5i      6-   �� 5j      6-   .+�5l      	� $��0��6"   $��0��6/   $��
20 0  5 0 q�6?   $	 radSelectionparameter��6S   ��5m      �� *CalendarSelectionCommand+
 6J   �� *StartEndDateTrue+$ Group1��$ PropertyChanged=�6�   �� 5n      $��0��6    $��1��6-   $��
Start Date��6=   6Q   �� 5o      $��1��6    $��1��6-   $��End Date��6=   6O   (  "System.Windows.Controls.DatePicker  5p      -   5        $
��Left=�5p   H   $	��150��6c   $	��150��6r   $��	-60 0 5 5q�6�   $��0��6�   $��2��5r      {�5p   !   �� *StartEndDateTrue+   SelectedDate 5r   -   �� *SelectedSearchStartDate+  5t      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7  �� 5u      "  6$   .�5v   "   ��  � �� 5w   &   �� 5x   *   .R�5y   .   �� $ PART_TextBox��66    . $��0q�6^   $��Stretch=�6r   $��Stretch=�6�   #���  6�   .��6�   ��5z   2   `� 5{   6   8   .1�5|   :   �� $ SelectedDate�6B   �� 5}   :   $ 
DateFormat�6B   6V   �� 5~   :   $) #DataContext.SelectedSearchStartDate�6B    5   A   �� "  5�   7   .��5�   @   5�   /   5�   +   5�   #   5�      5�      5�        5�      -   5        $
��Left=�5�   I   $	��150��6d   $	��150��6s   $��	-60 0 5 5q�6�   $��1��5�   �   $��2��6�   {�5�   !   �� *EnableEndDropDown+   DisplayDateStart 5�   h   �� *EndDateValidation+ 6�   �� *SelectedSearchEndDate+  5�      ��%�  '        7  �� 5�      "  6$   .�5�   "   ��  � �� 5�   &   �� 5�   *   .R�5�   .   �� $ PART_TextBox��66    . $��0q�6^   $��Stretch=�6r   $��Stretch=�6�   #���  6�   .��6�   ��5�   2   `� 5�   6   8   .1�5�   :   �� $ SelectedDate�6B   �� 5�   :   $ 
DateFormat�6B   6V   �� 5�   :   $' !DataContext.SelectedSearchEndDate�6B    5�   A   �� "  5�   7   .��5�   @   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      ]� 5�      $��0��6   $��4��6)   $��0 0 0 0q�69   $��2��6J   $��2��6^   .+�5�      �� $!��Select a Start and End date��6    
�������$��Italic$�6U   6k   5�      5�      �� 5�      $��0��6   $��3��6)   $	��Top=�66   $	��140��6N   $��25��6Z   $��	19 10 0 0q�6f   $
��Left=�5�        WaterMarkStyle#��[ 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [  6#   .1�5�      ��  �� ElementName$ cmbChequeNo��6"   $ Text.IsEmpty�6<   �� 5�      $ cmbChequeNo��6"   $ 	IsFocused�6<   5�      5�      �� 5�      -   5        $��cmbChequeNo��5�      
������ #��[ 5�   1   $��0��6e   $��3��6u    . $��13 5 0 0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   $	��220��6�   $	��220��6�   $ CashChequeNo��5�   )   $ CashChequeNo��6J   ��5�     �� *TransferMoneyListCash+ 5�      �� *SelectedCashChequeNo+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��2��6   $��3��6)   $	��Top=�66   $	��140��6N   $��25��6Z   $��
-48 10 0 0q�6f   $
��Left=�5�      #��[ 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [  6#   .1�5�      �� $ cmbFromAccountSearch��6"   $ Text.IsEmpty�6E   �� 5�      $ cmbFromAccountSearch��6"   $ 	IsFocused�6E   5�      5�      �� 5�      -	   5        $��cmbFromAccountSearch��5�   _   
������ #��[ 5�   1   $��2��6e   $��3��6u    . $��	-51 5 0 0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   $	��270��6�   $	��270��6�   $ FromAccountName��5�      $ FromAccountName��6;   ��5�     �� *TransferMoneyListFrom+ 5�      �� *SelectedFromAccount+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��3��6   $��3��6)   $	��Top=�66   $	��140��6N   $��25��6Z   $��
-31 10 0 0q�6f   $
��Left=�5�      #��[ 63   $��Search��6\   #��[ 6j   y�5�      `� 5�      # [  6#   .1�5�      �� $ cmbChequeNo��6"   $ Text.IsEmpty�6<   �� 5�      $ cmbChequeNo��6"   $ 	IsFocused�6<   5�      5�      �� 5�      -
   5        $��cmbToAccountSearch��5�   [   
������ #��[ 5�   1   $��3��6e   $��3��6u    . $��	-35 5 0 0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   $	��260��6�   $	��260��6�   $ ToAccountName��5�      $ ToAccountName��69   ��5�     �� *TransferMoneyListTo+ 5�      �� *SelectedToAccount+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��3��6   $��0��6'   $��4��67   $��0,35,0,0q�6K   $	��998��6]   .+�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5�      $��0��6`       GridLinesVisibility$	  All=�5�   P   !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����#   AutoGenerateColumns# .  $$   HorizontalScrollBarVisibility$$ Hidden=�5�      "%   VerticalScrollBarVisibility$% Disabled=�6C     BackHeaderStyle20&   ColumnHeaderStyle#& [ 5�      '   HeadersVisibility$	' All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�(   Columns( 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn)   Header$)  ��61   *   Width5  /System.Windows.Controls.DataGridLengthConverter$	* 220 6U   1	  +System.Windows.Controls.DataGridBoundColumn+ 	  Binding+ 6;   �� *Col1+6c     5�      $)  ��61   $	* 100 6U   + 6;   �� *Col4+6c     5�      $)  ��61   $	* 130 6U   + 6;   �� *Col4+6c     5�      $)  ��61   $	* 270 6U   + 6;   �� *Col4+6c     5�      $)  ��61   $	* 260 6U   + 6;   �� *Col4+6c   5�        5�      -   5        $	 dg1��5�   �   $��5��6   $	��100��63    . $	  All=�6�   $��1q�6�   ,   CanUserAddRows, .  -   CanUserDeleteRows- .  .   CanUserResizeColumns. .   	 HeaderStyle20#& [	 5�      $$ Disabled=�6K   
������ /   CanUserReorderColumns/ .  0   SelectionMode$0 Single=�6�   $	��Top=�6�   # .  ��5�   C   �� *TransferMoneyListGridHeight+��6�   �� *TransferMoneyList+( 5�      4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      -   5        CashChequeNo��1   MinWidth$	1 220Q�5�   K   2   MaxWidth$	2 220Q�6Z   $) Cash/Cheque No��6i   $
* Auto 6�   3   SortMemberPath$3 CashChequeNo��6�   4   HeaderTemplate4 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   �� 5�   .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5   1   $��20��6<   $
��Left=�5  ,   $��1��5  ,   5  +   5  '   5 
  CellTemplate5 5  "   �� 5  &   .R�5	  *   �� �� 5
  ,   6 �� Command6 66   �� *+)DataContext.NavigateToTransferFormCommand+ �� " >�7 �� CommandParameter7 5  2   �� *CashChequeNo+.�6\   .�5  2   �� ��6<   �� *CashChequeNo+5  .   5  *   5  '   5     
  5     -   5        Date��$	1 100Q�5  C   $	2 100Q�6R   $
) Date��6b   $3 CashChequeDate��6p    
 HeaderStyle20Right8   HeaderStyle#8 [
 6�   4 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   �� #��z��68   �� 5  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5  1   $��20��6<   $
��Left=�5  ,   $��1��5  ,   5   +   5!  '   5 5#  "   �� 5$  &   .R�5%  *   �� $��Right=�64   �� 5'  2   $
��Wrap=�6_   $��Right=�6s   ��6<   �� *CashChequeDateStr+6s   5)  /   5*  '   5,     
  5-     -   5        
Amount��$	1 130Q�5-  E   $) Amount��6U   $3 Amount��6e   #8 [
 6}   4 5.  "   �� 5/  &   .R�50  *   �  51  .   �� 52  2   $
��auto �6C   �� 53  2   $��10 �6D   .+�55  .   �� #��z��68   �� 56  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��57  1   $��20��6<   $
��Left=�58  ,   $��1��59  ,   5;  +   5<  '   5 5>  "   �� 5?  &   .R�5@  *   �� $��Right=�64   �� 5B  2   $
��Wrap=�6W   $��Right=�6k   ��6<   �� *	AmountStr+6k   5D  /   5E  '   5G     
  5H     -   5        FromAccountName��$	1 270Q�5H  N   $	2 270Q�6]   $) Transfered from Account��6l   $3 FromAccountName��6�   $
* Auto 6�   4 5I  "   �� 5J  &   .R�5K  *   �  5L  .   �� 5M  2   $
��auto �6C   �� 5N  2   $��10 �6D   .+�5P  .   �� #��z��68   �� 5Q  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5R  1   $��20��6<   $
��Left=�5S  ,   $��1��5T  ,   5U  +   5V  '   5 5X  "   �� 5Y  &   .R�5Z  *   �� $
��Left=�64   �� 5[  ,   6 66   �� *&$DataContext.NavigateToAccountCommand+ �� " >�7 5\  2   �� *FromAccountId+.�6]   .�5]  2   �� ��6<   �� *FromAccountName+5^  .   5_  *   5`  '   5b     
  5c     -   5        ToAccountName��$	1 260Q�5c  L   $	2 260Q�6[   $) Transfered to Account��6j   $3 ToAccountName��6�   $
* Auto 6�   4 5d  "   �� 5e  &   .R�5f  *   �  5g  .   �� 5h  2   $
��auto �6C   �� 5i  2   $��10 �6D   .+�5k  .   �� #��z��68   �� 5l  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5m  1   $��20��6<   $
��Left=�5n  ,   $��1��5o  ,   5p  +   5q  '   5 5s  "   �� 5t  &   .R�5u  *   �� $
��Left=�64   �� 5v  ,   6 66   �� *&$DataContext.NavigateToAccountCommand+ �� " >�7 5w  2   �� *ToAccountId+.�6[   .�5x  2   �� ��6<   �� *ToAccountName+5y  .   5z  *   5{  '   5}     5�     5�     �� 5�     $ 
Horizontal=�6   $
��left=�67   $��0,1,0,0q�6R   $��20��6c   .+�5�     � ��6   �� $ CashChequeNo��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $
 Date��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ Amount��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ FromAccountName��$ ActualWidth�.+�5�     ��   BorderStyleRight#��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 6u   ��6(   �� *TotalAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ ToAccountName��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� #��[ 6(   6W   5�     5�     � 5�     ��6   �� $ Remarks��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   64   5�     5�     5�     5�     �� 5�     $��4��6   $��0��6&   $��3��66   $ 
Horizontal=�6J   $��Bottom=�6c   $��10��6~   .+�5�     �� $��10 -10 10 0q�6   $��  Amounts are in��63   $��Italic$�6K   
�������6r   �� 5�     $��10 -10 10 0q�6:   $��Italic$�6P   
���������6   �� *CurrencyName+6w   5�     �� 5�     $ 
Horizontal=�6   $��3��62   $��4��6B   $��Right=�6O   $��0,0,10,0q�6l   $��Bottom=�6~   $��25��6�   $	��150��6�   .+�5�     �� $	��New��6   $��10 -10 10 0q�6(     ButtonStyle#���  6>   $	��New��6�   ��6d   �� *NavigaetoFormCommand+6�   �� 5�     $��Close��6   $��
10 -10 0 0q�6P   #���  6d   ��6)   �� $ CloseCommand�6d   5�     5�     5�     5�     