   M S B A M L   `   `   `  ����I  ESDN.Navigation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SDN.Navigation.ViewModelSDN.Navigation.ViewModel  5      '    !SDN.Navigation.View.LoginUserView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4v&clr-namespace:SDN.Navigation.ViewModel     5      -   5        $	��180��5      $	��300��6   
���   �$��1q�6;   .��5
      �   � RowDefinitions  5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   6-   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $��	User Name��62   $��20 10 10 10q�6C   6Z   �� 5   
   $��1��6   $��0��6!   $��Password��61   $��20 10 10 10q�6A   6X   �� 5   
   -   5         ��Name$ txtName��5   /   $��0��6   $��1��6   $	��170��6�   ��6@   �� *
UserName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   G� 5   
   -   5         G�Name$ PasswordBox��5   [   
���   �$��1��6*   $��
10 8 10 10q�67   $��1��6K   $	��170��6p   6~   �� 5   
   -   5        $��login��5      $��60��6   $��Login��6]   $
��Left=�6�   $��10 0 0 0q�6�   $��22��6�      AuditTrialButton#���   6�   $��2��6�   $��1��6�   6
  �� 5   
   -   5        $��60��5      $
��Exit��6;   $��Right=�6J   $��	10 0 10 0q�6f   $��22��6y   #���   6�   $��2��6�   $��1��6�   6�   �� 5   
   $��3��6   $��2��6!   $��	25 20 0 0q�65   $.��(@2017 Simple Accounting Software Pte Ltd��6H   6z   5      56      