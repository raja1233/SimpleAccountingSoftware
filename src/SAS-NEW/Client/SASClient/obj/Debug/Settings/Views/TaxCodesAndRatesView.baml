   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SDN.Settings.ViewsSDN.Settings.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      -    'SDN.Settings.Views.TaxCodesAndRatesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:SDN.Settings.Views     5      M
Convertors6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��Auto��5
      $
��Auto��6-     � 	Resources  5      0  *SDN.Common.Converter.SelectedItemConvertor   SelectedItemToItemsSource-  'SDN.Common.Converter.YesNoBoolConverter  	YesNoBool.  (SDN.Common.Converter.RowToIndexConverter  RowToIndexConverter 	 dttax �� CornerRadius �� 
TargetType �� Property �� Value � RowDefinitions � ColumnDefinitions �� 	MaxLength �� Mode	 �� UpdateSourceTrigger
 �� NotifyOnValidationError d� 	IsChecked �� 	Converter  
ErrorStyle �� Triggers P� Property P� Value �� Self �� RelativeSource �� Path��%�  &	        &	      &	 &     &	 9     7  &	 �      5   
   6+     5   
   6<     5   
   6)   �� 5   
   .R�5      �� 
�������
���   �$��1q�6<   $ 0��5      ._�5      � $��10q�6     5      ���� 5      '��       " ��6    .�5      ��  � ��$ 0,0,0,5q�67   �� 5       � ��$ 25��67   �� 5       � ��
 �   �6<   5      5       5      �� 5      �� 5       �� 5!      6*   �� 5"      6*    5$      �� 5%      $	��100 �6+   �� 5&      $	��230 �6+   .+�5(      �� $��0��6    $��0��6-   $��Tax Description��6=   5)      �� 5*      $��1��6    $��0��6-   $��Tax Code��6>   5+      �� 5,      $��2��6    $��0��6-   $��Tax Rate (%)��6=   5-      �� 5.      $��3��6    $��0��6-   $��Inactive��6=   5/      ]� 50      $��0��6"   $��1��6/   .+�51      �� 
���  ��$��*��65   �� 52      $��txtTaxDescription��62   -   5        $	 100��52   "   $��2,0,0,0q�6K   $	��230��6\   $	��300��6l   ��53      �� *TaxDescription+$ TwoWay=�$	 PropertyChanged=�
 . 54   e   55      ]� 56      $��1��6    $��1��6-   $��0,2,0,0q�6=   .+�57      �� 
���  ��$��*��65   �� 58      $��
txtTaxCode��62   $ 10��6#   $��2,0,0,0q�6D   ��59      �� *	TaxCode+$ TwoWay=�$	 PropertyChanged=�
 . .��6�   5:      5;      �� 5<      $��
txtTaxRate��6Z   -   5        $��7,2,0,0q�5<      $��2��6/   $��1��6<   $ 6��6L   ��5=   P   �� *	TaxRate+$ TwoWay=�$	 PropertyChanged=�
 . 6�   �� 5>      $��chkInactive��60   $��7,2,0,0q�6   $
��Left=�6C   $��3��5?      $��1��6,    6=   �� *
IsInActive+$ TwoWay=�$	 PropertyChanged=�8   6�   5@      5A      5B      �� 5D   
   " �5E       5F      P� 5G       �@=�HasError . . �5I      ��  �@�ToolTip 5J      �� # Z $2 ,(Validation.Errors).CurrentItem.ErrorContent�5M      5O      5Q      .��5R      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5T   
   � $��0,10,0,0q�6    5U      �� 5V      $
��Auto �6    60   �� 5W      $��3* �6!   6/   �� 5X      $��4* �6    6.   �� 5Y      $��2* �6!   6/   �� 5Z      $��1* �6!   6/    5\      �� 5]      $
��auto �6#   5^      �� 5_      $��1* �6#   5`      �� 5a      $��1* �6#   60   .+�5d      ]� $��0��6   $��0��6(   $
��Left=�65   .+�5p      �� $��Tax Name��6   $
��Left=�6,   $��Center=�6G   $��	10,10,0,5q�6b   5q      �� 5r      -   5        $��
cmbTaxName��5r      $
��Left=�6.   $��Bottom=�6I   
���   �$ �� IsSynchronizedWithCurrentItem$
 TrueY�5s   *   $��10,0,0,5q�6O    �� SelectedValue 6b   �� *SelectedTaxName+$ TwoWay=�$	 PropertyChanged=���5t      �� $ TaxNameList�5v      5w      ]� 5z      $��0��6   $��1��6(   .+�5{      � $	��501��6   $	��600��6D   $��0��6T   $��0��6a   $��10 0 0 0q�6q   ��6$   �� *POGridHeight+.+�5|      � .+�5}      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5}   #   $��0��6d   $��6��6t      GridLinesVisibility$	 All=�5~   _      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�5�      "   VerticalScrollBarVisibility$ Disabled=�6C     BackHeaderStyle20   ColumnHeaderStyle# [ 5�         HeadersVisibility$	 All=�6R   $��0,0,0,0q�6j   ��5}   <   �� *BackGroundLines+��5~      ��  �� ElementName$ dgTaxCodesAndRates��$ ActualHeight���6{   �� $ dgTaxCodesAndRates��$ ActualWidth�   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn    Header$   ��65   !   Width5  /System.Windows.Controls.DataGridLengthConverter$! 20 6Y   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6?   �� *Col0+6f     5�   "   $   ��65   $	! 227 6Y   " 6?   �� *Col1+6g     5�   "   $   ��65   $! 70 6Y   " 6?   �� *Col2+6f     5�   "   $   ��65   $! 70 6Y   " 6?   �� *Col3+6f     5�   "   $   ��65   $! 50 6Y   " 6?   �� *Col4+6f     5�   "   $   ��65   $! 50 6Y   " 6?   �� *Col5+6f   #   	CellStyle# 5�      �� 5�   "   *	  $System.Windows.Controls.DataGridCell" 	 6(    5�   &   P� 5�   *    �@	 
IsSelected . . �5�   .   ��  � ��
 �   �5�   2   �� 5�   .    � ��
 �����5�   5   �� 5�   .    � ��
 �����5�   2   5�   +   5�   #   5�        5�      -   5        $ dgTaxCodesAndRates��5�   k   $	 All=�6#   $��6��6=   
������ $
��Left=�5�      $	��501��67   $	��600��6c   $	��200��6r   $   CanUserAddRows$ .  %   CanUserDeleteRows% .  &   CanUserResizeColumns& . '   CanUserReorderColumns' .  $��Center=�5�   {    .  ( �� SelectedValuePath$( TaxID��5�      $
 TrueY�6+   )   CanUserSortColumns) . $��1q�6j   
���   �$��0,0,0,0q�5�      $ Hidden=�6i     HeaderStyle20# [ 5�      ��5�   C   �� *POGridHeight+* �� SelectedItem* 5�   +   �� *SelectedTax+$ TwoWay=�$	 PropertyChanged=�+ �� SelectedIndex+ 6�   �� *SelectedIndex+��5�   (   �� *Tax+  5�      )
  #System.Windows.Controls.DataGridRow, �� 	Resources- �� Color��%Y  '��       '
  �     �� 5�      " ��6$   .�5�   "   ��  � ��
 �   �6@   �� 5�   "    � ��$ 1q�6D   �� 5�   "    �@��CornerRadius$ 0��6A   5�      �� 5�      " 
 6$   , 5�   "   ���� 5�   &   $- 	LightGray��6y   (��       66   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6y   5�   #   5�      5�       5�        5�      $   ��61   .   
IsReadOnly. . $! 20 6f   " 6;   �� *Rank+6s     5�      $	! 227 61   -   5        TaxDesc��$  Tax Decription��5�   N   . . " 6f   �� *TaxDescription+/   HeaderTemplate/ 5�   &   �� 5�   *   .R�5�   .   �  5�   2   �� 5�   6   6F    5�   2   �� 5�   6   ��6G   �� $ TaxDesc��$ ActualWidth�.+�5�   2   ]� $��0��6<   $��0��6I   .+�5�   6   �� $��txtHeadertaxname��6@   �� 5�   "   $�Tax Decription��6&   6>   5�   7   �� 5�   6   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��6<   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   5�   3   5�   /   5�   +   0   ElementStyle0 5�   &   �� 5�   &   .�5�   *   ��  � ��$
 Wrap=�6S   5�   '   5�        5�      $! 70 61   $  Tax Code��6<   . . " 6N   �� *	TaxCode+6j     5�      $! 70 61   $  
Tax Rate %��6<   . . " 6P   �� *
StrTaxRate+6o   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $! 50 65   $  Inactive��6@   . . 1   CellTemplate1 5�   "   �� 5�   &   .R�5�   *   �� {�.   63   �� *
IsInActive+# [ $ TwoWay=�$	 PropertyChanged=�6�   5�   '   5�        5�      $  Default��65   $! 50 6F   1 5�   "   �� 5�   &   .R�5�   *   	� 2 	� 	GroupName$2 
grpdefault��6�    66   �� *	IsDefault+$ TwoWay=�$	 PropertyChanged=�6�   5�   '   5�        5�      $! 0 61   $   ��6;   3   
Visibility$3 Hidden=�6E   " 6Y   �� *
Predefined+6z   .  (System.Windows.Interactivity.Interaction4   Triggers4 5�      /  )System.Windows.Interactivity.EventTrigger  5�      5   	EventName$5 SelectionChanged��6-   .  (System.Windows.Interactivity.TriggerBase6   Actions.6 5�   "   6  0System.Windows.Interactivity.InvokeCommandAction  7   Command7 68   �� *TaxSelectChangeCommand+5�      # 5�      �� 5�   "   " 	 6(    5�   &   P� 5�   *    �@	 
IsSelected . . �5�   .   ��  � ��
 �   �5�   2   �� 5�   .    � ��
 �����5�   5   �� 5�   .    � ��
 �����5�   2   5�   +   5�   #   8   RowStyle8 5      �� 5  "   " 
 6(    5  &   P� 5  *    �@
 
IsSelected . . �5  .   ��  � ��
 �   �5  2   �� 5  .    � ��
 �   �5  5   �� 5	  .    � ��
 �����5
  2   5  +   5  #   5     5     5     5     �� 5     -   5        $��TaxItemControl��5     $��1��5     $��1��6,   $��5,0,0,0q�6<   #��[ 5     $
��Left=�66   ��5  M   �� *SelectedTax+# [  5     � 5     $��1��6   $��0��6$   $
��auto��61   $
��Left=�6>   $��5,0,0,1q�6Y    5     �� 5     6&    5      �� 5!     $��1* �6'   64   �� 5"     $��1* �6'   64   �� 5#     $��1* �6'   64   .+�5%     �� $��0,0,10,5q�6     ButtonStyle#��[ 6,   $��Delete��6Q   $��Bottom=�5&     $��0��64   $��0��6D   $��Right=�6Q   ��5%  b   �� *DeleteCommand+5&  o   �� 5'     -   5        $��btnNew��5(  5   $��0,0,10,5q�5'     #��[ 6+   $	��New��6Q   $��1��6~   $��0��6�   $��Right=�6�   $��Bottom=�5(     ��5'  _   �� *
NewCommand+5(  �   �� 5)     -	   5        $��btnSave1��5*  5   $��0,0,30,5q�5)     #��[ 6+   $
��Save��6Q   $��2��6�   $��0��6�   $��Right=�6�   $��Bottom=�5*     ��5)  `   �� *SaveRowCommand+5*  H   5+     � 5-     $��0��6   $��3��6#   $	��150��60   5/     � 50     $��2��6   $��4��6$   $��Right=�61   $��	0,0,10,10q�6M   $��Bottom=�6`    51     �� 52     6&    55     �� 56     6)   �� 57     6)   �� 58     6)   �� 59     6)   .+�5<     �� -
   5        $��btnSave��5<     $��	0,-5,10,0q�6(   #��[ 6;   $
��Save��6a   $��2��6�   $��0��6�   $
��Left=�6�   $��Bottom=�6�   ��6p   �� *SaveCommand+6�   �� 5=     -   5        $��	btnCancel��5=     $��	10,-6,0,0q�6*   #��[ 6^   $��Close��6�   $��3��6�   $��0��6�   $
��Left=�6�   $��Bottom=�6�   ��6=   �� *CloseCommand+6�   5>     ]� 5?     $��0��6   $��3��6(   $��2��65   $��	10,0,0,10q�6I   $��Bottom=�6\   $��2��6w   .+�5@     �  5A     �� 5B     6*   �� 5C     6*   �� 5D     6*   �� 5E     6*   .+�5H     �� 
�������$��0��6.   $��Italic$�6;   $e��_# GST Free cannot be deleted or made inactive. Description and Code can be edited but not rate.��5K  &   5L     �� 5M     
�������$��1��62   $��Italic$�6?   $����If your Company is registered to collect GST/VAT enter registration details in Company Details and enter Tax Description, Codes and Rates here.��5P  &   5Q     �� 5R     
�������$��2��62   $��Italic$�6?   $Q��KIf your Company is NOT registered to collect GST/VAT,set default GST to 0%.��5U  &   5V     �� 5W     
�������$��3��62   $��Italic$�6?   $x��rCreate other taxes such as Customs Duty in Accounts> Costs, and enter transactions in Purchases>Business Expenses.��5Z  &   5[     5\     5]     �� 5c     $��1��6   $��1��6&   
���  ��$
��Wrap=�6G   $��
10,120,0,0q�6[   $	��345��6o   $
��Left=�5d     $	��Top=�6)   ��6A   �� *	TaxErrors+$	 PropertyChanged=�6�   5f     5h     5i     