   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.Accounts.ViewsSASClient.Accounts.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      3    -SASClient.Accounts.Views.GstAndVatSummaryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.Accounts.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��1024��5
      .��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter5  /SDN.Common.Converter.MultipleParameterConverter  MultiParamterConverter4  .SDN.Common.Converter.BoolToVisibilityConverter  BoolToVisConverter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%e  &	        &	      &	 &     &	 9     &	 L     &	 �     &	 �     &	 �       5      69     5      6H     5      6V     5      6Q   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��69 �6    6.   �� 5       $��5 �6    6-   �� 5!      $
��Auto �6    60   �� 5#      $��40 �6    6.    � ColumnDefinitions 5%      �� 5&      $	��256 �6#   61   �� 5'      $	��256 �6#   61   �� 5(      $	��256 �6#   61   �� 5)      $	��256 �6#   61   .+�5+      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��4��6B   $��0��6V   $��0 10 0 0q�6c   .+�5,      �� $ 
Horizontal=�6   $��0��66   $��
7,0,256,10q�6F   $��2��6Z   .+�5-      	� -   5         	�Name$ radShowAllYes��5-      $��2 2 10 2q�6Y   	 	� 	GroupName$	 radSelectionparameter��6m   $��14��6�   $
��Left=�6�   ��65   �� *ShowAllCommand+
 d� 	IsChecked
 6�   �� *ShowAllTrue+ �� BindingGroupName$ Group1�� �� UpdateSourceTrigger$ PropertyChanged=�.��5.      ]� .+�5/      �� $��	Show All ��6%   68   52      53      54      � 55      $��
-200 0 0 0q�6   $	��250��6,   $	��250��6;    56      �� 57      6-   �� 58      6-   �� 59      6-    5;      �� 5<      6*   �� 5=      6*   .+�5?      	� -   5        $ radyearmonthYes��5?   ?   $��0��6"   $��0��6/   $	 radSelectionparameter��6X   $��	-20 0 0 0q�6z   ��5@      �� *YearQuarterSelectedCommand+
 6G   �� *YearmonthQuartTrue+$ Group1��$ PropertyChanged=�6�   �� 5A      $��0��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $
��Year��6u   6�   �� 5B      $��0��6    $��1��6-   $��Center=�6=   $��Center=�6Z   $��Quater��6u   6�   �� 5C      $��0��6    $��2��6-   $��Center=�6=   $��Center=�6Z   $��Month��6u   6�   �� 5D      -   5        $��cmbYearSearch��5F   I   
���   �$��1��5D   3   $��0��6@    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5F       �� SelectedValuePath$
 Year��60   {�5D   P   �� *EnableYearDropDown+��5E      �� *	YearRange+ �� SelectedValue 5G      �� *SelectedSearchYear+ �� Mode$ TwoWay=�$ PropertyChanged=�6w   �� 5H      -   5        $��cmbQuarterSearch��5M   J   
���   �$��1��5H   3   $��1��6@    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5M      $ ID��63   {�5H   P   �� *EnableQuarterDropDown+ w� TextPath 5K      �� *	Quarter+��5L      �� *QuarterList+ 5N      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5O      -   5        $��cmbMonthSearch��5Q   H   
���   �$��1��5O   3   $��2��6@    . $ Month��5Q      $ ID��61   {�5O   P   �� *EnableMonthDropDown+��5P      �� *	MonthList+ 5R      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5T      $��0��6   $��0��6-   #��[ 6:   6a   �� 5U      $��0��6   $��1��6-   #��[ 6:   6a   �� 5V      $��1��6   $��0��6-   #��[ 6:   6a   �� 5W      $��1��6   $��1��6-   #��[ 6:   6a   �� 5X      $��2��6   $��0��6-   #��[ 6:   6a   �� 5Y      $��2��6   $��1��6-   #��[ 6:   6a   5[      5\      �� 5^      $��2��6   $��0��6'   $��4��67   $��
-12,10,0,0q�6K   $	��985��6_   .+�5_      � .+�5`      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5`      $��0��6`      GridLinesVisibility$	 All=�5a   B      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�5c      "   VerticalScrollBarVisibility$ Disabled=�6C     BackHeaderStyle20   ColumnHeaderStyle# [ 5d         HeadersVisibility$	 All=�6R   $��0,0,0,0q�6j   ��5`   8   �� *BackGroundLines+��5a      �� *SIGridHeightSummary+��6^   ��  �� ElementName$	 dg1��  �� Path$  ActualWidth�!   Columns! 5e      0  *System.Windows.Controls.DataGridTextColumn  5f      ,  &System.Windows.Controls.DataGridColumn"   Header$"  ��61   #   Width5  /System.Windows.Controls.DataGridLengthConverter$	# 150 6U   1	  +System.Windows.Controls.DataGridBoundColumn$ 	  Binding$ 6;   �� *Col0+6c     5g      $"  ��61   $# 80 6U   $ 6;   �� *Col1+6b     5h      $"  ��61   $# 80 6U   $ 6;   �� *Col4+6b     5i      $"  ��61   $	# 180 6U   $ 6;   �� *Col4+6c     5j      $"  ��61   $	# 160 6U   $ 6;   �� *Col4+6c     5k      $"  ��61   $	# 160 6U   $ 6;   �� *Col4+6c     5l      $"  ��61   $	# 150 6U   $ 6;   �� *Col4+6c   5o        5p      -   5        $	 dg1��5p   �   $��5��6   $	��100��63    . $	 All=�6�   $��1q�6�   %   CanUserAddRows% .  &   CanUserDeleteRows& .  '   CanUserResizeColumns' .  (   CanUserSortColumns( .   	 HeaderStyle20# [	 5q   2   $ Disabled=�6f   
������ )   CanUserReorderColumns) .  *   SelectionMode$* Single=�6�   $	��Top=�6�    .  ��5p   C   �� *SIGridHeightSummary+��6�   �� *GstAndVatSummaryEntityList+! 5r      4
  .System.Windows.Controls.DataGridTemplateColumn
  5s      -   5        TaxDescription��+   MinWidth$	+ 150Q�5s   M   ,   MaxWidth$	, 150Q�6\   $"  Tax Description��6k   $
# Auto 6�   -   HeaderTemplate- 5t   "   �� 5u   &   .R�5v   *   �  5w   .   �� 5x   2   $
��auto �6C   �� 5y   2   $��10 �6D   .+�5{   .   �� #��z��68   5|   +   5}   '   . 
  CellTemplate. 5   "   �� 5�   &   .R�5�   *   �� �� 5�   2   $
��Left=�6c   ��6<   �� *TaxDescriptionSummary+6c   5�   *   5�   '   5�      
  5�      -	   5        TaxCode��$+ 80Q�5�   F   $, 80Q�6T   $" 	 Tax Code��6b   $
# Auto 6u   - 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5�   +   5�   '   . 5�   "   �� 5�   &   .R�5�   *   �� �� 5�   2   $
��Left=�6\   ��6<   �� *TaxCodeSummary+6\    �� 5�   .   / �� Command/ 68   �� *&$DataContext.NavigateToProductCommand+0 �� RelativeSource0 �� 1 �� AncestorType"1 >�2 �� CommandParameter2 5�   2   �� *CashChequeNo+.�6\   5�   .   5�   *   5�   '   5�      
  5�      -
   5        TaxRate��$+ 80Q�5�   F   $, 80Q�6T   $" 	 Tax Rate��6c    
 HeaderStyle20Right3   HeaderStyle#3 [
 6w   - 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5�   +   5�   '   . 5�   "   �� 5�   &   .R�5�   *   �� $��Right=�64   �� 5�   2   4 �� TextAlignment$4 Right=�6\   $
��Wrap=�6r   ��6<   �� *TaxRateSummary+6r   5�   /   5�   '   5�      
  5�      -   5        InvoiceCNAmount��$	+ 180Q�5�   N   $"  Invoice/CN Amount��6^   #3 [
 6{   - 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5�   +   5�   '   . 5�   "   �� 5�   &   .R�5�   *   �� $��Right=�6_   $4 Right=�6{   $
��Wrap=�6�   ��64   �� *TaxInvoiceCNAmountSummary+6�   5�   '   5�      
  5�      -   5        TaxCollected��$	+ 160Q�5�   K   $	, 160Q�6Z   $"  Tax Collected��6i   #3 [
 6�   - 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5�   +   5�   '   . 5�   "   �� 5�   &   .R�5�   *   �� $4 Right=�6Y   $��Right=�6o   ��64   �� *TaxCollectedSummary+6o   5�   '   5�      
  5�      -   5        InvoiceDNAmount��$	+ 160Q�5�   N   $"  Invoice/DN Amount��6^   #3 [
 6{   - 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5�   +   5�   '   . 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�6_   $4 Right=�6s   $��Right=�6�   ��64   �� *TaxInvoiceDNAmountSummary+6�   5�   '   5�      
  5�      -   5        TaxPaid��$	+ 150Q�5�   F   $	, 150Q�6U   $" Tax Paid��6e   #3 [
 6x   - 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5   +   5  '   . 5  "   �� 5  &   .R�5  *   �� $
��Wrap=�6T   $4 Right=�6h   $��Right=�6~   ��64   �� *TaxPaidSummary+6~   5  '   5     5     5     �� 5     $ 
Horizontal=�6   $��3��67   $��0��6D   $
��left=�6T   $��0,0,0,0q�6o   .+�5     � ��6   �� $ TaxDescription��$  ActualWidth�.+�5     ��   BorderStyleLeft#��[ 6!   ._�5     �� $��Total��6)   $
��Bold"�66   6J   5     5     � 5     ��6   �� $ TaxCode��$  ActualWidth�.+�5     �� #��[ 6!   ._�5     �� $�� ��6(   63   5     5     � 5     ��6   �� $ TaxRate��$  ActualWidth�.+�5     �� #��[ 6!   ._�5     �� $�� ��6(   64   5     5     � 5     ��6   �� $ InvoiceCNAmount��$  ActualWidth�.+�5     �� #��[ 6!   ._�5      ��   DisplayTotalStyle#��[ 6�   ��6(   �� * TotalTaxInvoiceCNAmountSummary+$ TwoWay=�$ PropertyChanged=�6�   5"     5#     � 5$     ��6   �� $ TaxCollected��$  ActualWidth�.+�5%     �� #��[ 6!   ._�5&     �� #��[ 6�   ��6(   �� *TotalTaxCollectedSummary+$ TwoWay=�$ PropertyChanged=�6�   5'     5)     � 5*     ��6   �� $ InvoiceDNAmount��$  ActualWidth�.+�5+     �� #��[ 6!   ._�5,     �� #��[ 6y   ��6(   �� *TotalInvoiceDNAmountSummary+$ PropertyChanged=�6�   5.     50     � 51     ��6   �� $ TaxCollected��$  ActualWidth�.+�52     ��   BorderStyleRight#��[ 6!   ._�53     �� #��[ 6n   ��6(   �� *TotalPaidSummary+$ PropertyChanged=�6�   54     55     56     57     �� 5a     $��	14 20 0 0q�6   $��3��6,   $��4��6@   $��0��6M   .+�5b     �� 
�������$��Italic$�6.   $��CN: CreditNote��6A   6Y   �� 5c     
�������$��100 -17 0 0q�6.   $��Italic$�6C   $��DN: DebitNote��6V   6m   �� 5d     $��200 -17 0 0q�6   $��Amounts are in  ��64   $��Italic$�6L   
�������6s   �� 5e     $��305 -17 0 0q�6;   $��Italic$�6P   
���������6   �� *CurrencyName+6w   5f     �� 5g     $ 
Horizontal=�6   $��4��62   $��4��6B   $��Right=�6O   $��Bottom=�6k   $��0,0,-9,0q�6�   .+�5i     �� $��Close��6   $
��30 0q�6*     ButtonStyle#���  68   $	��New��6   ��6^   �� *CloseCommand+6   5j     5k     5l     5m     