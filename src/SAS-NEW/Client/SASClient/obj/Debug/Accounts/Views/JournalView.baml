   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SASClient.Accounts.ViewsSASClient.Accounts.Views  5      E ASDN.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:SDN.Common.Converter;assembly=SDN.CommonSDN.Common.Converter 5      ;,clr-namespace:SDN.Common;assembly=SDN.Common
SDN.Common 5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      *    $SASClient.Accounts.Views.JournalView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SASClient.Accounts.Views     5      Jhelpers6clr-namespace:SDN.Common.Converter;assembly=SDN.Common     5      ;my,clr-namespace:SDN.Common;assembly=SDN.Common     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      $
��1024��5
        � 	Resources  5      ,  &SDN.Common.Converter.DateTimeConverter   DateTimeFormatter  BorderStyle �� 
TargetType �� Property �� Value  TextBoxStyle  brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder��%_  &	        &	      &	 �     &	 �     &	 �     &	       5   
   6@   �� 5   
   " ��6$   .�5      ��  � ��$ 1q�60   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6%   .�5      ��  � ��$ 0q�60   5      �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   5      .��5      �� $��Stretch=�6   $
��Auto=�62   $
��Auto=�6U   .��5   
   �   5        
ComboStyle��%#  '��       &	 �     �� 5       " ��6   .�5!      ��  � ��$ 25��6/   6<   �� 5"       � ��$ 0,0,0,4q�6/   �� 5#       � ��
 �   �64   5$      �� 5%      " ��6+   .�5&      ��  � ��$ 0,0,0,4q�6/   �� 5'       � ��
 �   �64   5(      5)       � RowDefinitions 5*      �� 5+      $��70 �6    6.   �� 5,      $
��Auto �6    60   �� 5-      $��30 �6    6.   �� 5.      $��40 �6    6.    � ColumnDefinitions 50      �� 51      $	��700 �6#   61   �� 52      $	��256 �6#   61   .+�55      ]� $��0��6   $��Right=�6%   $��0,0,0,0q�6A   $��2��6R   $	��232��6f   .+�56      �� -   5        $��lblStockCountNo��56   .   $��
Journal No��6   57      �� 58      -   5        $��txtStockCountNo��58      $	��150��61   $��	0,-40,0,0q�6=    �� 
IsReadOnly . ��6b   �� *	JournalNo+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   59      ]� 5:      $��0��6   $��Right=�6%   $��0,35,0,0q�6A   $	��282��6S   $��2��6_   .+�5;      �� -   5        $��lblJournalDate��5;   )   $
��Date��6   $��Right=�6?   $��49,0,0,0q�6[   5<      �� 5=      -   5        $��	StarLabel��5=   6   $��*��6   
���  ��$��Right=�6G   $��2,0,0,0q�6c   5>      (  "System.Windows.Controls.DatePicker  5?      -   5        $��JournalDatepicker��5@      $��25��5?      $	��150��6)   $
��Left=�65   $��	40,-1,0,0q�6Q   $	��Top=�5A   �   
   SelectedDate
 6   �� *JournalDateCalender+ �� BindingGroupName$ Group1��$	 PropertyChanged=�  5B      :  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name  BaseBorderBrush `� 	Converter �� Path �� RelativeSource �� AncestorType��%�  '        7   �� 5C      "  6    .�5D      ��  � �� 5E   "   �� 5F   &   .R�5G   *   �� $ Date_TextBox��62    . $��0q�6[   $��Stretch=�6o   $��Stretch=�5H   .   $y�Hidden=�6Q   #���  6e   .��6�   ��5I   .   `� 5J   2   8   .1�5K   6   �� $ SelectedDate�6>   �� 5L   6   $ 
DateFormat�6>   6R   �� 5M   6   $% DataContext.JournalDateCalender�6>    5N   A   �� "  5O   3   .��5P   <   5Q   +   5R   '   5T      5U      5V      5W      �� 5X      -   5        $��parttextbox��5X      $��
-148 1 0 0q�6-   $	��Top=�6A   $
��Left=�6Y   $��21��6t    .  $��0 0 0 0q�6�   $��Stretch=�6�   $��Stretch=�5Y      $	��120��6�   ��65   �� $ JournalDateStr�$ TwoWay=�$	 PropertyChanged=�.��6�   5[      5\      �� 5]       �� Orientation$ Vertical=�6   $��1��60   $��0��6=   $��3��6M   $��0,20,5,5q�6a   .+�5^      �  5_      �� 5`      $	��50* �6+   .+�5c      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomGridLines��5c         GridLinesVisibility$	 All=�5d   P      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .  $��15,0,0,0q�5e      $   HorizontalScrollBarVisibility$ Hidden=�5f      "   VerticalScrollBarVisibility$ Disabled=�6C   $
��Left=�6j     BackHeaderStyle20   ColumnHeaderStyle# [ 5g         HeadersVisibility$	 All=�6R   ��5c   8   �� *BackGroundLines+��5d      ��  �� ElementName$	 dg1��$ ActualHeight���6l   �� $	 dg1��$ ActualWidth�   Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$  ��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Col0+6b     5j      $  ��61   $	 170 6U    6;   �� *Col1+6c     5k      $  ��61   $	 170 6U    6;   �� *Col2+6c   5o        5p      -   5        $	 dg1��5p   U     �� IsTextSearchEnabled  . $	 All=�6:   $��0��6b   !   CanUserAddRows! .  "   CanUserDeleteRows" .  #   SelectionMode$# Single=�5q   Q   $	��Top=�6h   $ Hidden=�5r   9   $	��660��6b    .  $��1q�5s      
������ $
��Left=�6M   $��15,0,0,0q�6h    	 HeaderStyle20# [	 5t   c   $��2��6�   ��5p   r   �� *JournalDetailsEntity+$ TwoWay=�$	 PropertyChanged=���5r      �� *SIGridHeight+ 5v      4	  .System.Windows.Controls.DataGridComboBoxColumn	  5w      $	 300 66   -	   5        TxtAccountName��$   SortMemberPath$$ AccountName��5w   Z   % 	  DisplayMemberPath$% AccountName��5x      & 	  SelectedValuePath$& ID��5y      ' 	  SelectedValueBinding' 5{      �� *ID+$ TwoWay=�$	 PropertyChanged=�(   HeaderTemplate( 5|   "   �� 5}   &   .R�5~   *   �  5   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ TxtAccountName��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��txtHeaderPandScode��6<   �� 5�   "   $�Account Name��6&   6<   5�   3   �� 5�   2   $6��0/SASClient;component/Images/Shorting-Arrow-2.png��68   $��10��5�   1   $��20��6<   $
��Left=�5�   ,   �� 5�   2   $��*��6<   
���  ��6X   5�   /   5�   +   5�   '   ) 	  ElementStyle) 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � �� 6I   �� $! DataContext.JournalServices� �� "  �� 5�   *    � �� 5�   .   �� 5�   2   .R�5�   6   � * �Name$* gd��6;   
���   �$	��350��6f    5�   :   �� 5�   >   $	��200 �6O   �� 5�   >   $	��150 �6O   .+�5�   :   �� $��0��6D   ��6T   �� *AccountName+5�   7   + �� Triggers+ 5�   6   P� 5�   :   , P� Property, �@��
IsSelected- P� Value- . . �5�   >   �� . �� 
TargetName$. gd��6E    � ��
 �����6{   �� 5�   >   $. gd��6E    � ��
 �   �6�   5�   ;   P� 5�   :   , �@J�IsMouseOver- . . �5�   >   �� $. gd��6E    � ��
 �����6{   �� 5�   >   $. gd��6E    � ��
 �   �6�   5�   ;   5�   3   5�   +   5�   '   / 	  EditingElementStyle/ 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  �@��
IsEditable . 6V   �� 5�   *    � y�$ Visible=�6G   6Y   �� 5�   *    � �� 6I   �� $! DataContext.JournalServices� �� "  �� 5�   *    � �� 5�   .   �� 5�   2   .R�5�   6   � $* gd��6;   
���   �$	��350��6f    5�   :   �� 5�   >   $	��200 �6O   �� 5�   >   $	��150 �6O   .+�5�   :   �� $��0��6D   ��6T   �� *AccountName+�� 5�   :   $��1��6D   ��6T   �� *AccountTypeCode+5�   7   + 5�   6   P� 5�   :   , �@��
IsSelected- . . �5�   >   �� $. gd��6E    � ��
 �����6{   �� 5�   >   $. gd��6E    � ��
 �   �6�   5�   ;   P� 5�   :   , �@J�IsMouseOver- . . �5�   >   �� $. gd��6E    � ��
 �����6{   �� 5�   >   $. gd��6E    � ��
 �   �6�   5�   ;   5�   3   5�   +   5�   '   5�        5�      -
   5        TxtDebit��0   CanUserSort0 .  $ Debit��5�   X   $	 170 6h    6t   �� *Debit+$ TwoWay=�$	 	LostFocus=�( 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ TxtDebit��$ ActualWidth�.+�5�   .   ]� $��0��68   $��0��6E   .+�5�   2   �� $��Right=�6<   �� 5�   #   $�Debit��6'   67   5�   /   5�   +   5�   '   1   ElementStyle1 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � ��$ Right=�6P   5�   '   2   EditingElementStyle2 5�   "   �� 5�   &   " ��6,   .�5�   *   ��  �@��	MaxLength$ 10��6F   �� 5�   *    � ��$ Right=�6W   5�   '   5�        5�      -   5        	TxtCredit��0 .  $ Credit��5�   Y   $	 170 6j    6v   �� *Credit+$ TwoWay=�$	 	LostFocus=�( 5�   "   �� 5�   &   .R�5�   *   �  5�   .   �� 5�   2   6B    5�   .   �� 5�   2   ��6C   �� $ 	TxtCredit��$ ActualWidth�.+�5  .   ]� $��0��68   $��0��6E   .+�5  2   �� $��Right=�6<   �� 5  #   $�Credit��6'   68   5  /   5  +   5  '   1 5	  "   �� 5
  &   " ��6,   .�5  *   ��  � ��$ Right=�6P   5  '   2 5  "   �� 5  &   " ��6,   .�5  *   ��  �@��	MaxLength$ 10��6F   �� 5  *    � ��$ Right=�6W   5  '   5     5     5     �� 5     $ 
Horizontal=�6   $��18,0,0,0q�68   .+�5      � ��6   �� $ TxtAccountName��$ ActualWidth�.+�5!     ��  
 BorderStyleLeft#��[
 6!   $��-2,0,2,0q�6J   ._�5"     �� $�� Total��6)   $
��Bold"�67   3 �� TextAlignment$
3 Left=�6I   6`   5#     5$     � 5'     ��6   �� $ TxtDebit��$ ActualWidth�.+�5(     �� #��[
 6!   ._�5)     �� $��Right=�6r   $3 Right=�6�   $
��Bold"�6�   ��6(   �� *
sumDebit+$ TwoWay=�$	 PropertyChanged=�6�   5*     5+     � 5.     ��6   �� $ 	TxtCredit��$ ActualWidth�.+�5/     �� #��[
 6!   ._�50     �� $��Right=�6s   $3 Right=�6�   $
��Bold"�6�   ��6(   �� *	sumCredit+$ TwoWay=�$	 PropertyChanged=�6�   51     52     58     �� 59     $��15,5,0,0q�6   
�������$��Italic$�6A   $:��4Totals of Debit and Credit columns must be the same.��6T   6�   5:     ]� 5=     $��3��6   $��0��6%   $��2��65   $��15,-15,10,2q�6I   .+�5>     �� 
�������$��Italic$�6/   $	��607��6B   `^If you do not know which account is to debit and which account is credit DO NOT use this form.5@     �� 5A     $��	-60,0,0,0q�6   $��  Amounts are in ��6/   $��Italic$�6H   
�������6o   �� 5B     $��Italic$�6:   
���������6   �� *CurrencyName+6a   5D     �� 5N     $��2��6   $��0��6&   
���  ��$
��Wrap=�6G   $��	350,0,0,5q�6[   $	��345��6n   $
��Left=�5O     ��6)   �� *
DateErrors+$	 PropertyChanged=��� 5P     $��2��6   $��1��6&   
���  ��$
��Wrap=�6G   $��	0,0,-65,5q�6[   $	��320��6n   $��Right=�5Q     ��6*   �� *	CASErrors+$	 PropertyChanged=�]� 5R     $��3��6   $��1��6%   $��Right=�65   $��	0,-10,4,0q�6Q   .+�5S     �� -   5        4 ��Name$4 btnNew��5S     $	��New��6)   $��10,0,0,0q�67     ButtonStyle#���  6I   $	��New��6�   ��6o   �� *NewJournalCommand+6�   �� 5T     -   5        $4 btnSave��5T     $
��Save��6+   $��10,0,0,0q�6:   #���  6L   ��6r   �� *SaveCommand+6�   �� 5U     -   5        $4 btnClose��5U     $��Close��6+   $��10,0,0,0q�6;   #���  6M   ��6s   �� *CloseCommand+6�   5V     5W     5X     5Y     