   M S B A M L   `   `   `  ����I  ESDN.Navigation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Navigation.ViewSDN.Navigation.View  5      -    'SDN.Navigation.View.OpenCompanyFileView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Navigation.View     5      $	��180��5      $	��300��6   
���   �$��1q�6;   .��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   	� -   5        $��RadioButton1��5   �   $��0��63   $��
10,10,0,13q�6@   $
��Left=�6�   $	��Top=�6�   $	��150��6�   $��15��6�   
���   ���6T   �� *SelectDBCommand+ d� 	IsChecked 6x   �� *IsOpenCompanyFileTrue+.��6  Open Company File5      	� 5   
   -   5        $��RadioButton2��5   �   $��1��63   $��
10,10,0,13q�6�   $
��Left=�6�   $	��Top=�6�   $	��150��6�   $��15��6�   
���   � 6@   �� *IsNewCompanyFileTrue+��6k   �� *CreateCompanyCommand+.��6  New Company File5      	� 5   
   -   5        $��RadioButton3��5   �   $��2��63   $��
10,10,0,13q�6�   $
��Left=�6�   $	��Top=�6�   $	��150��6�   $��15��6�   
���   � 6@   �� *
isExitTrue+.��6  Exit5      �� 5   
   $��3��6   $��	25 20 0 0q�6!   $.��(@2017 Simple Accounting Software Pte Ltd��64   6f   5       5,      