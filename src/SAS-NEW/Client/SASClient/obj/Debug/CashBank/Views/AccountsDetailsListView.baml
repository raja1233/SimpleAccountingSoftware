   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.CashBank.ViewsSASClient.CashBank.Views  5      ;"clr-namespace:SASClient.ConvertersSASClient.Converters  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
      6    0SASClient.CashBank.Views.AccountsDetailsListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.CashBank.Views     5      8	converter"clr-namespace:SASClient.Converters     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5	      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
      $
��1024��5        � 	Resources  5      9   3SASClient.Converters.AccountTypeVisibilityConverter "  AccountTypeVisibilityConverter1   +SASClient.Converters.CharToBooleanConverter  CharToBooleanConverter��%:   &	        &	        5   
   6\     5   
   6L   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $	��13* �6   6+   �� 5        � ColumnDefinitions 5"   
   �� 5#      $
��Auto �6   6.   �� 5$      $
��Auto �6   6.   .+�5'   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6/   $��8,7,5,10q�6<   .+�5(      	�  d� 	IsChecked$
 TrueY�6    	� 	GroupName$ grpAccountsDetailsList��6+   $	��All��6N     TabMenuButtonStyle#���  6]   $��0��6�   $��10,0,0,0q�6�   -  'System.Windows.Input.KeyboardNavigation   AcceptsReturn . ��5)   ;   �� *FilterAccountDetailsListClick+��6m   ��  �� RelativeSource ��  �� Mode$
 Self=�	 �� Path$	 Content�	� 5*      $ grpAccountsDetailsList��6   $��Assets��6>   #���  6P   $��1��6~   $��10,0,0,0q�6�    . ��5+   =   �� *FilterAccountDetailsListClick+��6o   ��  �� $
 Self=�$	 Content�	� 5,      $ grpAccountsDetailsList��6   $��Liabilities��6?   #���  6V   $��2��6�   $��10,0,0,0q�6�    . ��5-   =   �� *FilterAccountDetailsListClick+��6o   ��  �� $
 Self=�$	 Content�	� 5.      $ grpAccountsDetailsList��6   $��Capital��6>   #���  6Q   $��3��6   $��10,0,0,0q�6�    . ��5/   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$	 Content�	� 50      $ grpAccountsDetailsList��6   $��Income��6>   #���  6P   $��4��6~   $��10,0,0,0q�6�    . ��51   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$	 Content�	� 52      $ grpAccountsDetailsList��6   $��Costs��6>   #���  6O   $��5��6}   $��10,0,0,0q�6�    . ��53   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$	 Content�	� 54      $ grpAccountsDetailsList��6   $��Expenses��6>   #���  6R   $��6��6�   $��10,0,0,0q�6�    . ��55   >   �� *FilterAccountDetailsListClick+��6p   ��  �� $
 Self=�$	 Content�56      �� 58   
   $ Vertical=�6   $��1��6,   $��0��69   $��3 0 0 0q�6I   $
��1000��6Z   .+�59      � .+�5@      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 CustomGridLines��5@      $��0��6\      GridLinesVisibility$	 All=�5A   P      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�5C      "   VerticalScrollBarVisibility$ Disabled=�6C     BackHeaderStyle20   ColumnHeaderStyle# [ 5D         HeadersVisibility$	 All=�6R   $��8,0,0,0q�6j   ��5@   4   �� *BackGroundLines+��5A      ��  �� ElementName$	 dg1��$	 ActualHeight���6l   �� $	 dg1��$	 ActualWidth�   Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Col0+6_     5G      $  ��6-   $ 30 6Q    67   �� *Col1+6^     5H      $  ��6-   $ 65 6Q    67   �� *Col2+6^     5I      $  ��6-   $	 247 6Q    67   �� *Col3+6_     5J      $  ��6-   $	 160 6Q    67   �� *Col4+6_     5K      $  ��6-   $	 160 6Q    67   �� *Col5+6_     5L      $  ��6-   $	 179 6Q    67   �� *Col6+6_   5O        5P      -   5        $	
 dg1��5R   F   
������  �� IsTextSearchEnabled . $��Visible=�5P   }      SelectionUnit$
 Cell=�5Q   R   $	 All=�5R      $��1q�62      CanUserAddRows .    HeaderStyle20# [ 5S      $��10,0,2,0q�6O      CanUserSortColumns .     CanUserDeleteRows .     SelectionMode$ Single=�6�   $	��Top=�6�    .  ��5P   4   �� *AccountDetailsGridHeight+   CurrentCell 5Q      �� *
CellInfo+ �� Mode$ OneWayToSource=���5R   S   �� *AccountsDetailsList+$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=� 5T      4	  .System.Windows.Controls.DataGridTemplateColumn	  5U      -   5        AccountType��!   MinWidth$	! 130Q�5U   F   "   MaxWidth$	" 130Q�6U   $ Account Type��6d   $
 Auto 6{   #   HeaderTemplate# 5W      �� 5X   "   .R�5Y   &   �  5Z   *   �� 5[   .   6>    5^   *   �� 5_   .   ��6?   �� $ AccountType��$	 ActualWidth�.+�5a   *   ]� $��0��64   $��0��6A   .+�5b   .   �� #��z��68   5c   /   5g   +   5i   '   5j   #   $ 	  CellTemplate$ 5l      �� 5m   "   .R�5n   &   �� ��60   �� *AccountType+y�5o   *   `� 5p   .   % `� 	Converter#% [  6;   .1�5q   2   �� $%	 DataContext.AccountsDetailsList�6:    6a   �� & �� AncestorType$& DataGridL��� 5r   2   5s   /   5u   '   5v   #   5x      	  5y      -   5        Hash��$! 30Q�5y   ?   $" 30Q�6M   $  ��6[   $
 Auto 6f   # 5{      �� 5|   "   .R�5}   &   �  5~   *   �� 5   .   6>    5�   *   �� 5�   .   ��6?   �� $
 Hash��$	 ActualWidth�.+�5�   *   ]� $��0��64   $��0��6A   .+�5�   .   �� #��z��68   5�   /   5�   +   5�   '   5�   #   $ 5�      �� 5�   "   .R�5�   &   �� ��60   �� *IsHyperLink+5�   '   5�   #   5�      	  5�      -   5        
IsInactive��$ 65 5�   E   $" 65Q�6P   $! 65Q�6^   $ Inactive��6m   # 5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   6>    5�   *   �� 5�   .   ��6?   �� $ 
IsInactive��$	 ActualWidth�.+�5�   *   ]� $��0��64   $��0��6A   .+�5�   .   �� #��z��68   5�   /   5�   +   5�   '   5�   #   $ 5�      �� 5�   "   .R�5�   &   ��  6/   �� $	 
IsInactive�' �� 	Converter#' [ 5�   #   5�      	  5�      -   5        AccountName��$	 247 5�   F   $	" 247Q�6R   $	! 247Q�6a   $ Account Name��6q   # 5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   6>    5�   *   �� 5�   .   ��6?   �� $ AccountName��$	 ActualWidth�.+�5�   *   ]� $��0��64   $��0��6A   .+�5�   .   �� #��z��68   5�   /   5�   +   5�   '   5�   #   $ 5�      �� 5�   "   .R�5�   &   �� �� 5�   ,   ( �� Command( 66   �� *,*DataContext.NavigateToAccountDetailCommand+ �� "& >�) �� CommandParameter) 5�   2   �� *ID+.�6R   .�5�   2   �� ��6<   �� *AccountName+5�   .   5�   *   5�   #   5�      	  5�      -   5        OpeningBalance��$	! 160Q�5�   I   $	" 160Q�6X   $ Opening Balance��6g   $
 Auto 6�   # 5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   6>    5�   *   �� 5�   .   ��6?   �� $ OpeningBalance��$	 ActualWidth�.+�5�   *   ]� $��0��64   $��0��6A   $��Right=�6Q   .+�5�   .   �� #��z��68   $��Right=�6Y   5�   /   5�   +   5�   '   5�   #   $ 5�      �� 5�   "   .R�5�   &   �� $��Right=�60   �� 5�   &   $	��100��60   $��Right=�6_   * �� TextAlignment$* Right=�6{   ��6?   �� *OpeningBalance+6�   5�      5�   #   5�      	  5     -   5        
YearToDate��$	! 160Q�5  E   $	" 160Q�6T   $ Year-To-Date��6c   $
 Auto 6z   # 5     �� 5  "   .R�5  &   �  5  *   �� 5	  .   6>    5  *   �� 5  .   ��6?   �� $ 
YearToDate��$	 ActualWidth�.+�5  *   ]� $��0��64   $��0��6A   .+�5  .   �� #��z��68   $��Right=�6Y   5  /   5  +   5  '   5  #   $ 5     �� 5  "   .R�5  &   �� $��Right=�6L   ��60   �� *
YearToDate+5  '   5  #   5      	  5!     -	   5        CurrentBalance��$	! 179Q�5!  I   $	" 179Q�6X   $ Current Balance��6g   # 5#     �� 5$  "   .R�5%  &   �  5&  *   �� 5'  .   6>    5*  *   �� 5+  .   ��6?   �� $ CurrentBalance��$	 ActualWidth�.+�5-  *   ]� $��0��64   $��0��6A   $��Right=�6Q   .+�5.  .   �� #��z��68   $��Right=�6Y   5/  /   53  +   55  '   56  #   $ 58     �� 59  "   .R�5:  &   �� $��Right=�6Q   $* Right=�6m   ��61   �� *CurrentBalance+5;  '   5<  #   5>     +   	CellStyle+ 5N     �� 5O     , �� 
TargetType*
  $System.Windows.Controls.DataGridCell", 
 6    - �� Triggers- 5P     P� 5Q  "   . P� Property. �@
 
IsSelected/ P� Value/ . . �5S  &   �� 0 �� Property0 � ��1 �� Value
1 �   �5T  2   �� 5U  &   0 � ��
1 �   �5V  5   �� 5W  &   0 � ��
1 �����5X  2   5Z  #   5\     2   RowStyle2 5^     �� 5_     )  #System.Windows.Controls.DataGridRow",  6    - 5`     P� 5a  "   . �@ 
IsSelected/ . . �5c  &   �� 0 � ��
1 �   �5d  2   �� 5e  &   0 � ��
1 �   �5f  5   �� 5g  &   0 � ��
1 �����5h  2   5j  #   5l     5n     5o     5q     �� 5t  
   $��	13,8,0,24q�6   $��2��6'   $C��=#Linked accounts cannot be made inactive, renamed or deleted.��65   $��Italic$�6z   
�������$��2��6�   6�   �� 5u  
   $��	13,2,0,28q�6   $��3��6'   $}��wIf the totals of Assets minus Liabilities is not equal to Capital, Simple will post the difference to Suspense Account.��65   $��Italic$�6�   
�������$��7��6�   6�   �� 5w  
   $��  Amounts are in ��6   $��Italic$�6.   
�������$��654,2,254,28q�6S   $��3��6i   $��0��6v   $��Center=�6�   $��7��6�   6�   �� 5x  
   $��Italic$�62   $��760 -45 0 0q�6E   $��4��6Z   $��0��6g   
���������6   �� *CurrencyName+6�   �� 5{  
   $��Bottom=�6   $ 
Horizontal=�61   $��0��6J   $��10��6[   $��0,0,0,4q�6l   .+�5|     �� $��Bottom=�6   $	��300��60   $7��1Enter Previous Accounting System Closing Balances��6<   $
��10 0q�6y     ButtonStyle#���  6�   $	��New��6�   ��6�   �� *SystemClosingBalance+6�   �� 5}     $��Bottom=�6   $	��150��60   $��Start New Financial Year��6<   $��0 0 0 0q�6�   #���  6�   ��6_   �� *NewFinancialYear+6�   5~     �� 5  
   $��Bottom=�6   $ 
Horizontal=�60   $��0��6I   $��10��6Z   $��Right=�6i   $��0,0,0,4q�6�   .+�5�     �� $��Bottom=�6   $	��New��60   $
��10 0q�6?   #���  6M   $	��New��6�   ��6s   �� *
NewCommand+6�   �� 5�     $��Bottom=�6   $��Close��61   $
��10 0q�6B   #���  6P   ��5�  "   �� *CloseCommand+5�     5�     5�     