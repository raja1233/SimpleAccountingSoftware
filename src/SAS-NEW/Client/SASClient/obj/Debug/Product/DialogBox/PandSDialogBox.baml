   M S B A M L   `   `   `  ����D  @SASClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SDN.Product.DialogBoxSDN.Product.DialogBox  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   *    $SDN.Product.DialogBox.PandSDialogBox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SDN.Product.DialogBox     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$" Search Products and Services��5	   	   $	��400��6.   $	��400��6;   .��5
      � $��30,30,30,30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��10 �6   6,   �� 5      $��1* �6   6,   .+�5   
   �� $��P&S Code��6   $��0��6(   $��0��65   $
��auto��6E   $��0,0,0,4q�6S   6f   �� 5   
   $��1��6   $��1��6!   $��0��6.   $��20��5       �� DisplayMemberPath$ PSCode��6C    �� SelectedValuePath$ ID��6^   $��0,0,0,4q�5       �� SelectedValue 5   >   �� *SelectedPandSID+��5      �� *ProductAndServices+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5          	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5!      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 60   �� *PandSSelectionChangedCommand+5"      5$      �� 5&   
   $��P&S Name��6   $��0��6(   $��2��65   $��0,0,0,4q�6E   6X   �� 5'   
   $��1��6   $��2��6    $��0,0,0,4q�60   $��2��5(   <   $��Bottom=�6I   $��20��5)      $ PSName��6Q   $ ID��6l    5(      �� *SelectedPandSID+��5)   &   �� *ProductAndServices+ 5*        5+      $ SelectionChanged��6%   .	 5,        
 60   �� *PandSSelectionChangedCommand+5-      5/      �� 51   
   $��2��6   $��0��6!   $��Quantity��61   6D   �� 52   
   $��3��6   $��0��6!   $��Price��61   6@   �� 53   
   $��4��6   $��0��6!   $��Disc%��61   6@   �� 54   
   $��5��6   $��0��6!   $��Amount��61   6A   �� 55   
   $��6��6   $��0��6!   �� 56      �6   �� *	TaxName+ �� 57      $�%��6   58      �� 5:   
   -   5        $��txtQty��5:      $��2��6    $��2��6-   $��0,0,0,4q�6=   ��6N   �� *Qty+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�    5;        5<      $ TextChanged��6!   .	 5=        
 6,   �� *TextChangedCommand+5>      .��5?   &   5@      �� 5A   
   -   5        $��txtPrice��5A      $��3��6"   $��2��6/   $��0,0,0,4q�6?    �� 
IsReadOnly . ��6P   �� *Price+6{   �� 5B   
   -   5        $��txtDisc��5B       �� 	MaxLength$ 3��6!   $��4��6/   $��2��6<   $��0,0,0,4q�6L   ��6]   �� *
Discount+$ TwoWay=�$ PropertyChanged=�.��6�    5C        5D      $ TextChanged��6!   .	 5E        
 6,   �� *TextChangedCommand+5F      .��5G   &   5H      �� 5I   
   -   5        $��	txtAmount��5I      $��5��6#   $��2��60   $��0,0,0,4q�6@    . ��6c   �� *Amount+6}   �� 5J   
   -   5        $��txtTax��5J      $��6��6    $��2��6-   $��0,0,0,4q�6=    . ��6N   �� *	TaxRate+6{   ]� 5L   
   $��7��6   $��2��6!   .+�5M   
   �� -   5        $��btnOK��5M         ButtonStyle#��[  6   $��OK��6C   $��Bottom=�5N      $��Right=�6,   6J   �� 5O      -   5        $��	btnCancel��5O      #��[  6&   $��Cancel��6K   $��Bottom=�5P      $��Right=�6,   6J   5Q      5R      5S      