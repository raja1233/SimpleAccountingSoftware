   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.CashBank.ViewsSASClient.CashBank.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      /    )SASClient.CashBank.Views.PayMoneyListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.CashBank.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      $
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
 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��5,      ]� .+�5-      �� $��	Show All ��6%   68   �� 5/      $�� ��6%   6/   50      51      ]� 5:      $��0��6   $��4��6,   $��2��6@   $��1��6Q   $	��600��5;      $	��600��6(   $
��Left=�67   $��10 0 0 0q�6R   .+�5<      � $	��300��6   $	��300��6,    5=      �� 5>      $
��.25* �6/   6>   �� 5?      61   �� 5@      61   �� 5A      61    5C      �� 5D      6.   �� 5E      6.   .+�5G      	� -   5        $ radyearmonthYes��5G   C   $��0��6&   $��0��63   $	 radSelectionparameter��6\   $��0 0 5 0q�6~   ��5H      �� *YearQuarterSelectedCommand+
 6G   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5I      $��0��6$   $��1��61   $��Center=�6A   $��Center=�6^   $
��Year��6y   6�   �� 5J      $��0��6$   $��2��61   $��Center=�6A   $��Center=�6^   $��Quater��6y   6�   �� 5K      $��0��6$   $��3��61   $��Center=�6A   $��Center=�6^   $��Month��6y   6�   �� 5L      -   5        $��cmbYearSearch��5N   I   
���   �$��1��5L   7   $��1��6D    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5N       �� SelectedValuePath$
 Year��60   {�5L   T   �� *EnableYearDropDown+��5M      �� *	YearRange+ �� SelectedValue 5O      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6w   �� 5P      -   5        $��cmbQuarterSearch��5U   J   
���   �$��1��5P   7   $��2��6D    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5U      $ ID��63   {�5P   T   �� *EnableQuarterDropDown+ w� TextPath 5S      �� *	Quarter+��5T      �� *QuarterLits+ 5V      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5W      -   5        $��cmbMonthSearch��5Y   H   
���   �$��1��5W   7   $��3��6D    . $ Month��5Y      $ ID��61   {�5W   T   �� *EnableMonthDropDown+��5X      �� *	MonthList+ 5Z      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5[      $��1��6!   $��0��61   #��[ 6>   6e   �� 5\      $��1��6!   $��1��61   #��[ 6>   6e   �� 5]      $��2��6!   $��0��61   #��[ 6>   6e   �� 5^      $��2��6!   $��1��61   #��[ 6>   6e   �� 5_      $��3��6!   $��0��61   #��[ 6>   6e   �� 5`      $��3��6!   $��1��61   #��[ 6>   6e   5a      � 5b      $	��300��6   $	��300��6+   $��10,0,0,0q�6:    5c      �� 5d      6.   �� 5e      6.    5g      �� 5h      $
��.30* �6/   6>   �� 5i      61   �� 5j      61   .+�5l      	� $��0��6&   $��0��63   $��
20 0  5 0 q�6C   $	 radSelectionparameter��6W   ��5m      �� *CalendarSelectionCommand+
 6J   �� *StartEndDateTrue+$ Group1��$ PropertyChanged=�6�   �� 5n      $��0��6$   $��1��61   $��
Start Date��6A   6U   �� 5o      $��1��6$   $��1��61   $��End Date��6A   6S   (  "System.Windows.Controls.DatePicker  5p      -   5        $
��Left=�5p   L   $	��150��6g   $	��150��6v   $��	-60 0 5 5q�6�   $��0��6�   $��2��5r      {�5p   %   �� *StartEndDateTrue+   SelectedDate 5r   -   �� *SelectedSearchStartDate+  5t      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� 
IsReadOnly  BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7  �� 5u   "   "  6(   .�5v   &   ��  � �� 5w   *   �� 5x   .   .R�5y   2   �� $ PART_TextBox��6:    . $��0q�6b   $��Stretch=�6v   $��Stretch=�6�   #���  6�   .��6�   ��5z   6   `� 5{   :   8   .1�5|   >   �� $ SelectedDate�6F   �� 5}   >   $ 
DateFormat�6F   6Z   �� 5~   >   $) #DataContext.SelectedSearchStartDate�6F    5   A   �� "  5�   ;   .��5�   D   5�   3   5�   /   5�   '   5�   #   5�      5�        5�      -   5        $
��Left=�5�   M   $	��150��6h   $	��150��6w   $��	-60 0 5 5q�6�   $��1��5�   �   $��2��6�   {�5�   %   �� *EnableEndDropDown+   DisplayDateStart 5�   h   �� *EndDateValidation+ 6�   �� *SelectedSearchEndDate+  5�      ��%�  '        7  �� 5�   "   "  6(   .�5�   &   ��  � �� 5�   *   �� 5�   .   .R�5�   2   �� $ PART_TextBox��6:    . $��0q�6b   $��Stretch=�6v   $��Stretch=�6�   #���  6�   .��6�   ��5�   6   `� 5�   :   8   .1�5�   >   �� $ SelectedDate�6F   �� 5�   >   $ 
DateFormat�6F   6Z   �� 5�   >   $' !DataContext.SelectedSearchEndDate�6F    5�   A   �� "  5�   ;   .��5�   D   5�   3   5�   /   5�   '   5�   #   5�      5�      5�      5�      ]� 5�      $��0��6   $��4��6)   $��0 0 0 0q�69   $��2��6J   .+�5�      �� $!��Select a Start and End date��6    
�������$��Italic$�6U   6k   5�      5�      �� 5�      $	��Top=�6     WaterMarkStyle#��[ 62   $��1��6[   $��3��6k   $��
-40 10 0 0q�6x   $��Search��6�   #��[ 6�   y�5�      `� 5�      # [  6#   .1�5�      ��  �� ElementName$ cmbCustomerNameSearch��6"   $ Text.IsEmpty�6F   �� 5�      $ cmbCustomerNameSearch��6"   $ 	IsFocused�6F   5�      5�      �� 5�      -   5        $��cmbCustomerNameSearch��5�   Y   
������ #��[ 5�   1   $��1��6e   $��3��6u    . $��	-43 5 0 0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   $	��140��6�   $	��140��6�   $ CashChequeNo��5�      $ CashChequeNo��68   ��5�     �� *PayMoneyListCash+ 5�      �� *SelectedCashChequeNo+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��3��6   $��0��6'   $��4��67   $��0,35,0,0q�6K   $	��998��6]   .+�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -	   5          Name$ CustomGridLines��5�      $��0��6`       GridLinesVisibility$	  All=�5�   P   !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����#   AutoGenerateColumns# .  $$   HorizontalScrollBarVisibility$$ Hidden=�5�      "%   VerticalScrollBarVisibility$% Disabled=�6C     BackHeaderStyle20&   ColumnHeaderStyle#& [ 5�      '   HeadersVisibility$	' All=�6R   $��0,0,0,0q�6j   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�(   Columns( 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn)   Header$)  ��61   *   Width5  /System.Windows.Controls.DataGridLengthConverter$	* 200 6U   1	  +System.Windows.Controls.DataGridBoundColumn+ 	  Binding+ 6;   �� *Col0+6c     5�      $)  ��61   $	* 140 6U   + 6;   �� *Col1+6c     5�      $)  ��61   $	* 100 6U   + 6;   �� *Col4+6c     5�      $)  ��61   $	* 130 6U   + 6;   �� *Col4+6c     5�      $)  ��61   $	* 180 6U   + 6;   �� *Col4+6c     5�      $)  ��61   $	* 230 6U   + 6;   �� *Col4+6c   5�        5�      -
   5        $	 dg1��5�   �   $��5��6   $	��100��63    . $	  All=�6�   $��1q�6�   ,   CanUserAddRows, .  -   CanUserDeleteRows- .  .   CanUserResizeColumns. .   	 HeaderStyle20#& [	 5�      $$ Disabled=�6K   
������ /   CanUserReorderColumns/ .  0   SelectionMode$0 Single=�6�   $	��Top=�6�   # .  ��5�   C   �� *PayMoneyListGridHeight+��6�   �� *PayMoneyList+( 5�      4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      -   5        CashAccountName��1   MinWidth$	1 200Q�5�   N   2   MaxWidth$	2 200Q�6]   $) Cash/Bank Account Name��6l   $
* Auto 6�   3   SortMemberPath$3 CashBankAccountName��6�   4   HeaderTemplate4 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   �� 5�   .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   $��1��5�   ,   5�   +   5�   '   5 
  CellTemplate5 5�   "   �� 5�   &   .R�5�   *   �� �� 5�   2   ��6<   �� *CashBankAccountName+5�   *   5�   '   5�      
  5�      -   5        CashChequeNo��$	1 140Q�5�   K   $	2 140Q�6Z   $) Cash/Cheque No��6i   $
* Auto 6�   $3 CashChequeNo��6�   4 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   �� 5�   .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5�   1   $��20��6<   $
��Left=�5   ,   $��1��5  ,   5  +   5  '   5 5  "   �� 5  &   .R�5  *   �� �� 5	  ,   6 �� Command6 66   �� *&$DataContext.NavigateToProductCommand+ �� " >�7 �� CommandParameter7 5
  2   �� *CashChequeNo+.�6\   .�5  2   �� ��6<   �� *CashChequeNo+5  .   5  *   5  '   5     
  5     -   5        Date��$	1 100Q�5  C   $	2 100Q�6R   $
) Date��6b   $3 CashChequeDate��6p    
 HeaderStyle20Right8   HeaderStyle#8 [
 6�   4 5  "   �� 5  &   .R�5  *   �  5  .   �� 5  2   $
��auto �6C   �� 5  2   $��10 �6D   .+�5  .   �� #��z��68   �� 5  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5  1   $��20��6<   $
��Left=�5  ,   $��1��5  ,   5  +   5   '   5 5"  "   �� 5#  &   .R�5$  *   �� $��Right=�64   �� 5&  2   $
��Wrap=�6_   $��Right=�6s   ��6<   �� *CashChequeDateStr+6s   5(  /   5)  '   5+     
  5,     -   5        
Amount��$	1 130Q�5,  E   $) Amount��6U   $3 Amount��6e   #8 [
 6}   4 5-  "   �� 5.  &   .R�5/  *   �  50  .   �� 51  2   $
��auto �6C   �� 52  2   $��10 �6D   .+�54  .   �� #��z��68   �� 55  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��56  1   $��20��6<   $
��Left=�57  ,   $��1��58  ,   5:  +   5;  '   5 5=  "   �� 5>  &   .R�5?  *   �� $��Right=�64   �� 5A  2   $
��Wrap=�6W   $��Right=�6k   ��6<   �� *	AmountStr+6k   5C  /   5D  '   5F     
  5G     -   5        AccountName��$	1 180Q�5G  J   $	2 180Q�6Y   $) Account Name��6h   $3 AccountName��6~   $
* Auto 6�   4 5H  "   �� 5I  &   .R�5J  *   �  5K  .   �� 5L  2   $
��auto �6C   �� 5M  2   $��10 �6D   .+�5O  .   �� #��z��68   �� 5P  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5Q  1   $��20��6<   $
��Left=�5R  ,   $��1��5S  ,   5T  +   5U  '   5 5W  "   �� 5X  &   .R�5Y  *   �� $
��Left=�64   �� 5Z  -   6 67   �� *&$DataContext.NavigateToAccountCommand+ �� " >�7 5[  2   �� *LinkedAccountID+.�6_   .�5\  2   �� ��6<   �� *AccountName+5]  .   5^  *   5_  '   5a     
  5b     -   5        Remarks��$	1 230Q�5b  F   $) Remarks��6V   $3 Remarks��6g   4 5c  "   �� 5d  &   .R�5e  *   �  5f  .   �� 5g  2   $
��auto �6C   �� 5h  2   $��10 �6D   .+�5j  .   �� #��z��68   �� 5k  .   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��64   $��10��5l  1   $��20��6<   $
��Left=�5m  ,   $��1��5n  ,   5p  +   5q  '   5 5s  "   �� 5t  &   .R�5u  *   �� $
��Left=�64   �� 5w  2   $
��Wrap=�6U   $��Right=�6i   ��6<   �� *	Remarks+6i   5y  /   5z  '   5|     5�     5�     �� 5�     $ 
Horizontal=�6   $
��left=�67   $��0,1,0,0q�6R   $��20��6c   .+�5�     � ��6   �� $ CashAccountName��$ ActualWidth�.+�5�     ��   BorderStyleLeft#��[ 6!   ._�5�     �� $��Total��6)   $
��Bold"�66   6J   5�     5�     � 5�     ��6   �� $ CashChequeNo��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     ��   DisplayTotalStyle#��[ 6{   ��6(   �� *ShowSelectedCount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $
 Date��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   63   5�     5�     � 5�     ��6   �� $ Amount��$ ActualWidth�.+�5�     ��   BorderStyleRight#��[ 6!   ._�5�     �� #��[ 6u   ��6(   �� *TotalAmount+$ TwoWay=�$ PropertyChanged=�6�   5�     5�     � 5�     ��6   �� $ AccountName��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� #��[ 6(   6W   5�     5�     � 5�     ��6   �� $ Remarks��$ ActualWidth�.+�5�     �� #��[ 6!   ._�5�     �� $�� ��6(   64   5�     5�     5�     5�     �� 5�     $��4��6   $��0��6&   $��3��66   $ 
Horizontal=�6J   $��Bottom=�6c   $��10��6~   .+�5�     �� $��10 -10 10 0q�6   $��  Amounts are in��62   $��Italic$�6J   
�������6q   �� 5�     $��10 -10 10 0q�6:   $��Italic$�6P   
���������6   �� *CurrencyName+6w   �� 5�     $��PM: Pay Money��6   $��0 -10q�61   $��Italic$�6@   
�������6g   5�     �� 5�     $ 
Horizontal=�6   $��3��62   $��4��6B   $��Right=�6O   $��0,0,10,0q�6l   $��Bottom=�6~   $��25��6�   $	��150��6�   .+�5�     �� $	��New��6   $��10 -10 10 0q�6(     ButtonStyle#���  6>   $	��New��6�   ��6d   �� *NavigaetoFormCommand+6�   �� 5�     $��Close��6   $��
10 -10 0 0q�6P   #���  6d   ��6)   �� $ CloseCommand�6d   5�     5�     5�     5�     