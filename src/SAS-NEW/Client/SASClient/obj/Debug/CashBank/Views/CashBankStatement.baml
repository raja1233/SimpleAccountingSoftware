   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.CashBank.ViewsSASClient.CashBank.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      0    *SASClient.CashBank.Views.CashBankStatement   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.CashBank.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��1024��5
       .��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter5  /SDN.Common.Converter.MultipleParameterConverter  MultiParamterConverter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%H  &	        &	      &	 &     &	 9     &	 �     &	 �     &	 �       5      69     5      6H     5      6V   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��30 �6    6.   �� 5      $��30 �6    6.   �� 5       $��50 �6    6.   �� 5!      $
��Auto �6    60   �� 5"      $��40 �6    6.    � ColumnDefinitions 5%      �� 5&      $	��256 �6#   61   �� 5'      $	��256 �6#   61   �� 5(      $	��256 �6#   61   �� 5)      $	��256 �6#   61   .+�56      � $��0��6   $��2��6#   $��0��67   $��2��6D   $	��300��6U   $	��300��6d   $
��Left=�6s   $��
-13,10,0,0q�6�    57      �� 58      $
��.25* �6'   66   �� 59      6)   �� 5:      6)   �� 5;      6)    5=      �� 5>      6&   �� 5?      6&   .+�5C      �� $��0��6   $��1��6)   $��Center=�69   $��Center=�6V   $
��Year��6q   6   �� 5D      $��0��6   $��2��6)   $��Center=�69   $��Center=�6V   $��Quater��6q   6�   �� 5E      $��0��6   $��3��6)   $��Center=�69   $��Center=�6V   $��Month��6q   6�   �� 5F      -   5        $��cmbYearSearch��5H   I   
���   �$��1��5F   /   $��1��6<    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5H      	 �� SelectedValuePath$
	 Year��60   {�5F   L   �� *EnableYearDropDown+��5G      �� *	YearRange+
 �� SelectedValue
 5I      �� *SelectedSearchYear+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6w   �� 5J      -   5        $��cmbQuarterSearch��5O   J   
���   �$��1��5J   /   $��2��6<    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5O      $	 ID��63   {�5J   L   �� *EnableQuarterDropDown+ w� TextPath 5M      �� *	Quarter+��5N      �� *QuarterList+
 5P      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5Q      -   5        $��cmbMonthSearch��5S   H   
���   �$��1��5Q   /   $��3��6<    . $ Month��5S      $	 ID��61   {�5Q   L   �� *EnableMonthDropDown+��5R      �� *	MonthList+
 5T      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5U      $��1��6   $��0��6)   #��[ 66   6]   �� 5V      $��1��6   $��1��6)   #��[ 66   6]   �� 5W      $��2��6   $��0��6)   #��[ 66   6]   �� 5X      $��2��6   $��1��6)   #��[ 66   $��Right=�6[   $��92��6w   6�   �� 5Y      $��3��6   $��0��6)   #��[ 66   6]   �� 5Z      $��3��6   $��1��6)   #��[ 66   6]   5\      �� 5^      $��15,28,122,0q�6   $��0��6.   $��2��6>   
�������$��2��6]   $��Stretch=�6q   $��Italic$�6�   @>Select a Cash, Bank or Credit Card Account to see Transactions6�   �� 5`      $��3��6   $��0��6'   .+�5a      � .+�5c      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines1��5c      $��0��6a      GridLinesVisibility$	 All=�5d   P      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $	��Top=�5f      $   HorizontalScrollBarVisibility$ Hidden=�63   "   VerticalScrollBarVisibility$ Disabled=�6Z     BackHeaderStyle20   ColumnHeaderStyle# [ 5g         HeadersVisibility$	 All=�6R   $��	10,35,0,0q�6m   ��5c   9   �� *BackGroundLines+��5d      ��  �� ElementName$	 dg2�� �� Path$ ActualHeight���6l   �� $	 dg2��$ ActualWidth�   Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Header$  ��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 210 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Col1+6c   5n        5o      -   5        $	 dg2��5o   b   $	 All=�6   $��0��69   
������     
IsReadOnly  . $��1q�6�   $	��240��6�   $	��240��6�   $��	10,35,0,0q�5p      !   CanUserAddRows! .  "   CanUserDeleteRows" .  $	��Top=�5q        HeaderStyle20# [ 6�   $	 CashBankAccountID��5r      #   CanUserSortColumns# . $   CanUserResizeColumns$ .  %   CanUserResizeRows% .   .  
���   ���5p   )   �� *SIGridHeight+��6J   �� $ CashBankStatementList�
 5q   1   �� *CashBankAccountID+$ TwoWay=�$ PropertyChanged=� 5t      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $	 210 65   &   MaxWidth$	& 210Q�6A   $# Cash/Bank/Credit Card Account��6P   '   CanUserSort' . (   SortMemberPath$( Cash/Bank Account��6�   )   HeaderTemplate) 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $	��10* �6@   6O   �� 5�   2   $��9* �6@    5�   .   �� 5�   2   ��6C   �� $ CashBankAccountName��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   $��2��6U   .+�5�   2   �� #��z��6<   5�   3   5�   /   �� 5�   .   $��0��65   $��0��6B    	 
HeaderLine#��[	 6R   $��2��6v   ._�5�   2   �� $�� ��6<   $��1��6E   $��0��6R   5�   /   5�   +   5�   '   * 	  CellTemplate* 5�   "   �� 5�   &   .R�5�   *   �� ��64   �� $ CashBankAccountName�6`   5�   '   5�        5�      )
  #System.Windows.Controls.DataGridRow+ �� 	Resources��%�   '
        �� 5�      " 
 6$   + 5�   "   ���� 5�   &   $
 Gray��6y   (��       66   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6y   5�   #   5�      5�      .  (System.Windows.Interactivity.Interaction,   Triggers, 5�      /  )System.Windows.Interactivity.EventTrigger  5�      -   	EventName$- SelectionChanged��6-   .  (System.Windows.Interactivity.TriggerBase.   Actions.. 5�   "   6  0System.Windows.Interactivity.InvokeCommandAction  /   Command/ 68   �� *SelectChangedCommand+5�      0   	CellStyle0 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"  6$   1 �� Triggers1 5�   "   P� 5�   &   2 P� Property2 �@ 
IsSelected3 P� Value3 . . �5�   *   ��  � ��
 �   �5�   2   �� 5�   *    � ��
 �   �5�   5   �� 5�   *    � ��
 �����5�   2   5�   '   5�      4   RowStyle4 5�      �� 5�      " 
 6$   1 5�   "   P� 5�   &   2 �@
 
IsSelected3 . . �5�   *   ��  � ��
 �   �5�   2   �� 5�   *    � ��
 �   �5�   5   �� 5�   *    � ��
 �����5�   2   5�   '   5�      5�      5�      5�      �� 5�      $��3��5�      $��1��6'   $��
16,37,10,0q�68   .+�5�      � $��
0,0,-492,0q�6    5�      �� 5�      $	��18* �6+   �� 5�      $	��31* �6+   �� 5�      $
��110* �6+   �� 5�      $	��24* �6+   �� 5�      $
��550* �6+   .+�5�        -   5        $ CustomGridLines��5�      $��0��6`   $	 All=�5�   P   
 �����
 ����� .  $ Hidden=�5�      $ Disabled=�6C   # [ 5�      $	 All=�6R   $��0,0,0,0q�6j   $��5��6{   ��5�   8   �� *BackGroundLines+��5�      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth� 5�        5�      $  ��61   $	 160 6U    6;   �� *Col1+6c     5�      $  ��61   $	 120 6U    6;   �� *Col2+6c     5�      $  ��61   $ 80 6U    6;   �� *Col3+6b     5�      $  ��61   $	 120 6U    6;   �� *Col4+6c     5�      $  ��61   $	 120 6U    6;   �� *Col4+6c     5�      $  ��61   $	 108 6U    6;   �� *Col4+6c   5�        5�      -   5        $	 dg1��5�   �    . $	 All=�5�   =   $ Disabled=�5�      $	��105��6<   $	��750��6L   $��1q�6|   ! .  # [ 5�      
������ " .  5   SelectionMode$5 Single=�6{   $	��Top=�6�    .  $��5��6�   $��0,0,-33.735,0q�6�   $
��Left=�6�   $	��722��6  ��5�   [   �� *SIGridHeight+��6�   �� *CashBankStatementDetailList+ 5      	  5!     -   5        Name��6   MinWidth$	6 160Q�5!  C   $	& 160Q�6T   $ Cus/Sup/Acc Name��6c   $
 Auto 6~   $
( Name��6�   ' .  ) 5"  "   �� 5#  &   .R�5$  *   �  5%  .   �� 5&  2   6B    5)  .   �� 5*  2   ��6C   �� $
 Name��$ ActualWidth�.+�5,  .   ]� $��0��68   $��0��6E   .+�5-  2   �� #��z��6<   $
��Left=�6^   52  /   53  +   54  '   * 56  "   �� 57  &   .R�58  *   �� $
��Left=�64   �� 59  *    
 HyperlinkDataGrid#��[
 65   7 �� Command7 6`   �� *DataContext.NavigatetoName+8 �� RelativeSource8 �� 9 �� AncestorType"9 >�: �� 	IsEnabled: 6�   �� *NoHyperLink+.�6�   .�5;  .   �� .F�5<  2   �� $
��Left=�6<   ��6W   �� *Name+5=  /   ; �� CommandParameter; 5>  .   `� 5?  .   < `� 	Converter#< [ 6;   .1�5@  3   �� $ ID�6;   �� 5A  3   $ TransactionType�6;   5B  0   .�5C  F   5D  +   67   5V  '   5Y     	  5Z     -	   5        Date��$	6 120Q�5Z  C   $	& 120Q�6R   $ Cash/Cheque No.��6a   $
 Auto 6{   $( TransactionDate��6�   ' .  ) 5[  "   �� 5\  &   .R�5]  *   �  5^  .   �� 5_  2   6B    5a  .   �� 5b  2   ��6C   �� $ DateTime��$ ActualWidth�.+�5d  .   ]� $��0��68   $��0��6E   $
��Left=�6U   .+�5e  2   �� #��z��6<   5j  /   5k  +   5l  '   * 5n  "   �� 5o  &   .R�5p  *   �� $
��Left=�64   �� 5q  *   7 65   �� *$"DataContext.NavigateToCashChequeNo+8 �� "9 >�.�5r  .   .�5t  .   �� .F�5u  *   �� $��Right=�64   ��6P   �� *
ChequeNo+5v  3   ; 5w  .   `� 5x  2   #< [ 6?   .1�5y  6   �� $ ChequeNo�6>   6P   �� 5z  6   $ TransactionType�6>   6W   5{  3   .�5|  J   5}  /   5~  /   5  '   5�     	  5�     -
   5        TransactionNo��$6 80Q�5�  L   $& 80Q�6Z   $
 Date��6h   $
 Auto 6w   $( TransactionNo��6�     HeaderStyle20Right=   HeaderStyle#= [ 6�   ' .  ) 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ TransactionNo��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� #��z��6<   $��Right=�6]   5�  /   5�  +   5�  '   * 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   �� 5�  4   $��Right=�6>   ��6Z   �� *CDate+5�  0   5�  '   5�     	  5�     -   5        	Price��$	6 120Q�5�  D   $	& 120Q�6S   $ Deposit��6b   $
 Auto 6t   $( TransactionDate��6�   #= [ 6�   ' .  ) 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ DateTime��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� #��z��6<   5�  /   5�  +   5�  '   * 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   ��6P   �� *
DepositStr+5�  '   5�     	  5�     -   5        	QtyIn��$	6 120Q�5�  D   $	& 120Q�6S   $ 
Withdrawal��6b   $
 Auto 6w   $( QtyIn��6�   #= [ 6�   ' .  ) 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ DateTime��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� #��z��6<   5�  /   5�  +   5�  '   * 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   ��6P   �� *WithdrawalStr+5�  '   5�     	  5�     -   5        Balance��$	6 106Q�5�  F   $	& 108Q�6U   $ Balance��6d   $
 Auto 6v   $( TransactionDate��6�   #= [ 6�   ' .  ) 5�  "   �� 5�  &   .R�5�  *   �  5�  .   �� 5�  2   6B    5�  .   �� 5�  2   ��6C   �� $ DateTime��$ ActualWidth�.+�5�  .   ]� $��0��68   $��0��6E   $��Right=�6U   .+�5�  2   �� #��z��6<   5�  /   5�  +   5�  '   * 5�  "   �� 5�  &   .R�5�  *   �� $��Right=�64   ��6P   �� *
BalanceStr+5�  '   5�     5�     5�     5�     �� 5�     $��10 0 0 0q�6   $��4��6+   $��0��68   $��3��6H   > �� Orientation$> 
Horizontal=�6\   $��Bottom=�6u   .+�5�     �� $��Italic$�6   
��������� 5�     $�Amounts include ��6   64    �� 5�     �6   �� *	TaxName+5      �� 5     $��Italic$�6:   
���������6   �� *CurrencyName+6a   5     �� 5     $��	270 0 0 0q�6   $��4��6-   $��0��6:   $��5��6J   $> 
Horizontal=�6^   $��Bottom=�6w   .+�5     �� 
�������$��Italic$�6.   $����PC: Payment from Customer, PS: Payment to Supplier, RC: Refund to Customer,
RS: Refund from Supplier, RM: Recieve Money, PM: Pay Money, TM: Transfer Money. ��6A   5     �� 5     $> 
Horizontal=�6   $��4��62   $��5��6B   $��Right=�6O   $��
10,10,10,0q�6l   $��Bottom=�6�   .+�5     �� $��Excel��6   $
��10 0q�6*     ButtonStyle#���  68   $	��New��6�   ��6^   �� *ExportCommand+6�   �� 5     $��Close��6   $
��17 0q�6P   #���  6^   ��6)   �� $ CloseCommand�6^   5     5     5     5     