   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SASClient.Customers.ViewsSASClient.Customers.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      9    3SASClient.Customers.Views.InvoiceCreditPaymentsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SASClient.Customers.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��1024��5
      .��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   � 	Resources  5      9  3SDN.Common.Converter.TextInputToVisibilityConverter "  TextInputToVisibilityConverter,  &SDN.Common.Converter.DateTimeConverter  DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%+  &	        &	      &	 &     &	 �     &	 �     &	 �       5      69     5      6H   �� 5      " ��6,   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �   �64   5      �� 5      $ White��6C   �� 5      $
 Gray��6C   �� 5      $ Black��6?   5       � RowDefinitions 5      �� 5      $��25 �6    6.   �� 5      $��25 �6    6.   �� 5      $��20 �6    6.   �� 5       $	��10* �6    6/   �� 5!      $��40 �6    6.    � ColumnDefinitions 5#      �� 5$      $	��300 �6#   63   �� 5%      $	��724 �6#   61   .+�5'      ]� $��0��6   $��4��6(   $��2��6<   $��0��6M   $	��300��5(      $	��300��6(   $
��Left=�67   $��10 0 0 0q�6R   .+�5)      � $	��300��6   $	��300��6(    5*      �� 5,      6-   �� 5-      6-   �� 5.      6-    50      �� 51      6*   �� 52      6*   .+�55      �� $��0��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $
��Year��6u   6�   �� 56      $��0��6    $��1��6-   $��Center=�6=   $��Center=�6Z   $��Quater��6u   6�   �� 57      $��0��6    $��2��6-   $��Center=�6=   $��Center=�6Z   $��Month��6u   6�   �� 58      -   5        $��cmbYearSearch��5:   I   
���   �$��1��58   3   $��0��6@    �� 
IsEditable .  �� DisplayMemberPath$
 Year��5:      	 �� SelectedValuePath$
	 Year��60   {�58   P   �� *EnableYearDropDown+��59      �� *	YearRange+
 �� SelectedValue
 5;      �� *SelectedSearchYear+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6w   �� 5<      -   5        $��cmbQuarterSearch��5?   J   
���   �$��1��5<   3   $��1��6@    .  �� IsTextSearchEnabled .   �� IsTextSearchCaseSensitive .   �� StaysOpenOnEdit . $ Quarter��5?      $	 ID��63   {�5<   P   �� *EnableQuarterDropDown+ w� TextPath 5>   .   �� *	Quarter+��6V   �� *QuarterList+
 5@      �� *SelectedSearchQuarter+$ TwoWay=�$ PropertyChanged=�6z   �� 5A      -   5        $��cmbMonthSearch��5C   H   
���   �$��1��5A   3   $��2��6@    . $ Month��5C      $	 ID��61   {�5A   P   �� *EnableMonthDropDown+��5B      �� *	MonthList+
 5D      �� *SelectedSearchMonth+$ TwoWay=�$ PropertyChanged=�6x   �� 5E      $��0��6   $��0��6-   #��[ 6:   6a   �� 5F      $��0��6   $��1��6-   #��[ 6:   6a   �� 5G      $��1��6   $��0��6-   #��[ 6:   6a   �� 5H      $��1��6   $��1��6-   #��[ 6:   6a   �� 5I      $��2��6   $��0��6-   #��[ 6:   6a   �� 5J      $��2��6   $��1��6-   #��[ 6:   6a   5K      5M      ]� 5N      $��0��6   $��4��6(   $��1��6<   $��2��6M   $
��Left=�5O      $��10 5 0 0q�64   .+�5P      �� $v��pSelect Customers to print statement. Click on a Customer name to see Invoices, Credit Notes and Payments details��6   $��Italic$�6�   
�������$��0,-3,0,3q�6�   6�   5Q      �� 5R      $��0��6   $��3��6(   $��35 8 0 0q�66     WaterMarkStyle#��[ 6J   $
��Left=�5S      $��Search��62   #��[ 6@   y�5T      `� 5U       `� 	Converter# [  6#   .1�5V      ��  �� ElementName$ cmbQuotNoSearch��6"    �� Path$ Text.IsEmpty�6@   �� 5W      $ cmbQuotNoSearch��6"   $ 	IsFocused�6@   5X      5Z      �� 5[      -   5        $��cmbQuotNoSearch��5^   W   
������ #��[ 5[   0   $��0��6d   $��3��6t    . $��2��5\      $
��Left=�6*   $��10 5 0 0q�6E   $��25��6W   $	��Top=�6f   $	��268��6~   $	��290��6�   $ CustomerName��5^      $	 
CustomerID��68   ��5]      �� *LstCustomers+
 5_      �� *SelectedCustomerID+$ TwoWay=�$ PropertyChanged=�5`      �� 5a      $��3��6   $��0��6'   $��0,1,0,39q�67   $��2��6I   .+�5b      � .+�5d      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5d      $��0��6`      GridLinesVisibility$	 All=�5e   P      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $	��Top=�5g      $   HorizontalScrollBarVisibility$ Hidden=�63   "   VerticalScrollBarVisibility$ Disabled=�6Z     BackHeaderStyle20   ColumnHeaderStyle# [ 5h         HeadersVisibility$	 All=�6R   $��	10,35,0,0q�6m   ��5d   8   �� *BackGroundLines+��5e      �� $	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�   Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Header$  ��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 20 6T   1  +System.Windows.Controls.DataGridBoundColumn    Binding  6;   �� *Col0+6a     5k      $  ��61   $	 255 6U     6;   �� *Col1+6c   5o        5p      -   5        $	 dg1��5p   b   $	 All=�6   $��0��69   
������ !   
IsReadOnly! . $��1q�6�   $	��290��6�   $	��290��6�   $��	10,35,0,0q�5q      "   CanUserAddRows" .  #   CanUserDeleteRows# .  $	��Top=�5r        HeaderStyle20# [ 6�   $	 
CustomerID��5s      $   CanUserSortColumns$ . %   CanUserResizeColumns% .  &   CanUserResizeRows& .   .  
���   ���5q   )   �� *
GridHeight+��6H   �� $ LstCustomers�
 5r   1   �� *SelectedCustomerID+$ TwoWay=�$ PropertyChanged=� 5u      4  .System.Windows.Controls.DataGridTemplateColumn  5v      $ 20 66    5w   "   �� 5x   &   -   5        5x   k   '   CellTemplate' 5z   "   �� 5{   &   .R�5|   *   �� ( d� 	IsChecked( 63   �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�5}   '   5        5�      $	 255 65   )   MaxWidth$	) 255Q�6A   $ Customer Name��6P   *   CanUserSort* . +   SortMemberPath$+ CustomerName��6z   ,   HeaderTemplate, 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ CustomerName��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� #��z��6<   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   /   �� 5�   .   $��1��65   $��0��6B    	 
HeaderLine#��[	 6R   ._�5�   2   �� $�� ��6<   $��1��6E   $��0��6R   5�   /   5�   +   5�   '   ' 5�   "   �� 5�   &   .R�5�   *   �� ��64   �� $ CustomerName�6Y   5�   '   5�        5�      )	  #System.Windows.Controls.DataGridRow- �� 	Resources��%�   '	        �� 5�      " 	 6$   - 5�   "   ���� 5�   &   $
 Gray��6y   (��       66   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6y   5�   #   5�      5�      .
  (System.Windows.Interactivity.Interaction. 
  Triggers. 5�      /  )System.Windows.Interactivity.EventTrigger  5�      /   	EventName$/ SelectionChanged��6-   .  (System.Windows.Interactivity.TriggerBase0   Actions.0 5�   "   6  0System.Windows.Interactivity.InvokeCommandAction  1   Command1 68   �� *SelectChangedCommand+5�      2   	CellStyle2 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"  6$   3 �� Triggers3 5�   "   P� 5�   &   4 P� Property4 �@ 
IsSelected5 P� Value5 . . �5�   *   ��  � ��
 �   �5�   2   �� 5�   *    � ��
 �   �5�   5   �� 5�   *    � ��
 �����5�   2   5�   '   5�      6   RowStyle6 5�      �� 5�      " 	 6$   3 5�   "   P� 5�   &   4 �@	 
IsSelected5 . . �5�   *   ��  � ��
 �   �5�   2   �� 5�   *    � ��
 �   �5�   5   �� 5�   *    � ��
 �����5�   2   5�   '   5�      5�      5�      5�      �� 5�      $��3��6   $��1��6'   $��
10,21,0,39q�68   $	��702��6L   $
��Left=�6X   $��2��6s   .+�5�      � .+�5�        -   5        $ CustomGridLines1��5�      $��0��6a   $	 All=�5�   �   
 �����
 ����� .  $ Hidden=�5�      $ Disabled=�6C   # [ 5�      $	 All=�6R   $��0,15,0,0q�6j   ��5�   9   �� *BackGroundLines+��5�      �� $
 dg11��$ ActualHeight���6Q   �� $
 dg11��$ ActualWidth� 5�        5�      $  ��61   $	 138 6U     6;   �� *Col1+6c     5�      $  ��61   $	 130 6U     6;   �� *Col2+6c     5�      $  ��61   $	 138 6U     6;   �� *Col3+6c     5�      $  ��61   $	 138 6U     6;   �� *Col4+6c     5�      $  ��61   $	 142 6U     6;   �� *Col4+6c   5�        5�      -	   5        $
 dg11��5�   �   $	��100��6    . $	 All=�6h   $��1q�6�   " .  # .  % .  # [ 5�      $��0,16,0,0q�6H   $	��702��6Z   $ Disabled=�6g   
������ 7   CanUserReorderColumns7 .  8   SelectionMode$8 Single=�6�   $	��Top=�6�    .  ��5�   /   �� *
GridHeight+��6�   �� *LstInvoiceDetails+ 5�        5�      -
   5        TransactionNo��9   MinWidth$	9 138Q�5�   L   $	) 138Q�6[   $ Transaction No.��6j   $
 Auto 6�   $+ TransactionNo��6�   * .  , 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   $
��auto �6C   �� 5�   2   $��10 �6D   .+�5�   .   �� #��z��68   5�   +   5�   '   ' 5�   "   �� 5�   &   .R�5�   *   �� �� 5�   ,    
 HyperlinkDataGrid#��[
 66   : �� Command: 6a   �� *+)DataContext.NavigateToTransferFormCommand+; �� RelativeSource; �� < �� AncestorType"< >�= �� CommandParameter= 5�   2   �� *TransactionNo+> �� 	IsEnabled> 6]   �� *NoHyperLink+.�6   .�5�   2   �� ��6<   �� *TransactionNo+5�   .   5�   *   5�   '   5�        5�      -   5        Date��$	9 130Q�5�   C   $	) 130Q�6R   $
 Date��6b   $+ CashChequeDate��6p   * .  ' 5�   "   �� 5�   &   .R�5�   *   �� $��Right=�64   �� 5�   2   $
��Wrap=�6`   $
��Left=�6t   ��6<   �� *TransactionDateStr+6t   5�   /   5�   '   5        5     -   5        InvoiceAmount��$	9 138Q�5  L   $	) 138Q�6[   $ Amount��6k   $+ InvoiceAmount��6{   * .  ' 5  "   �� 5  &   .R�5  *   �� $��Right=�64   �� 5  2   $
��Wrap=�6^   $��Right=�6r   ��6<   �� *InvoiceAmountStr+6r   5  /   5  '   5	       5
     -   5        CreditAmount��$	9 138Q�5
  K   $	) 138Q�6Z   $ Amount��6j   $+ CreditAmount��6z   * .  ' 5  "   �� 5  &   .R�5  *   �� $��Right=�64   �� 5  2   $
��Wrap=�6Z   $��Right=�6n   ��6<   �� *CNPaymentStr+6n   5  /   5  '   5       5     -   5        Balance��$	9 142Q�5  F   $	) 142Q�6U   $ Balance��6e   $+ Balance��6v   * .  ' 5  "   �� 5  &   .R�5  *   �� $��Right=�64   �� 5  2   $
��Wrap=�6X   $��Right=�6l   ��6<   �� *
BalanceStr+6l   5  /   5  '   5     5!     5"     5#     �� 5$     $��0 20 0 0q�6   $��4��6+   $��0��68   $��3��6H   ? �� Orientation$? 
Horizontal=�6\   $
��Left=�6u   $��Bottom=�6�   .+�5%     �� $��  Amounts including ��6   $��Italic$�69   
�������6`   �� 5&     $��Italic$�65   
���������6   �� *	TaxName+6\   �� 5'     $��      Amounts are in  ��6   $��Italic$�6;   
�������6b   �� 5(     $��Italic$�6:   
���������6   �� *CurrencyName+6a   �� 5)     $K��E      SI: Sales Invoice  CN: Credit Notes  PC: Payment From Customer ��6   $��Italic$�6j   
�������6�   5+     �� 5-     $? 
Horizontal=�6   $��3��64   $��4��6F   $��Right=�6S   $��	10,0,10,0q�6p   $��Bottom=�6�   .+�5.     �� $��Print��6   $��10 0 0 0q�6*     ButtonStyle#���  6<   $	��New��6�   ��6b   �� *PrintCommand+$ TwoWay=�6�   �� 5/     $��Close��6   $��10 0 0 0q�6P   #���  6b   ��6)   �� $ CloseCommand�6b   50     51     52     53     