   M S B A M L   `   `   `  ����S  OStaticCodeAnalysisClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:StaticCodeAnalysisClient.ViewsStaticCodeAnalysisClient.Views  5      0    *StaticCodeAnalysisClient.Views.ResultsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:StaticCodeAnalysisClient.Views     5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $! ../Styles/ToggleModule.xaml?�6%   %    5      .��5      � $
��Auto��6   $
��Auto��6    � ShowGridLines . 
������� � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��* �6   �� 5      $	��300 �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   $��Stretch=�6<   .+�5      �� $��10,0,0,0q�6   $
��Bold"�6*   $��Center=�6<   $��Center=�6W   $��20(�5      $��Italic$�6&   �� 6:   $�Repository Path��6>   6X   �� 5      -   5         ��Name$ gitRepoLink��5      $��30��6+   $
��Auto��67   $��0,0,0,10q�6D   $��Center=�6V   ��5      �� *ToolRunModel.RepoPath+�� 5       $��10,0,0,0q�6   $
��Bold"�6*   $��Center=�6<   $��Center=�6W   $��20(�5!      $��Italic$�6&   �� 6:   $�Branch Name��6>   6T   �� 5#      -   5        $ gitRepoBranch��5#      $��30��6-   $
��Auto��69   $��0,0,0,10q�6F   $��Center=�6X   ��5$      �� *ToolRunModel.Branch+{�6;   ��  �� ElementName$ RepositoryType�� �� Path$ 	IsChecked��� 5&      $��10,0,0,0q�6   $
��Bold"�6*   $��Center=�6<   $��Center=�6W   $��20(�5'      $��Italic$�6&   �� 6:   $�Tools��6>   6N   �� 5)      $��Center=�6   $	��100��64   	 �� DisplayMemberPath$	 Value��6n   
 �� SelectedValuePath$	
 Key��5*      ��5)   @   �� *ToolRunModel.AllTools+ �� SelectedValue 5*   /   �� *ToolRunModel.SelectedTool+ �� Mode$ TwoWay=��� 5,      $ 
Horizontal=�6   $��Center=�62   .+�5-      �� $
��Auto��6   $
��Auto��6)   $��20(�67   $��Center=�6E   $��Italic$�6`   $
��Bold"�6s   �� 5.      $�Local Folder��6   61   d� 5/      -   5        $��RepositoryType��5/   *   $��70��6   $��35��6@   $��10q�6L      SwitchTypeToggleButton#��[  50       d� 	IsChecked 6O   �� *ToolRunModel.RepoType+�� 51      $
��Auto��6   $
��Auto��6)   $��20(�67   $��Center=�6E   $��Italic$�6`   $
��Bold"�52      �� 6/   $�Github��63   6D   53      �� 55      $ 
Horizontal=�6   $��Center=�62   .+�56      �� $
��Auto��6   $
��Auto��6)   $��20(�67   $��Center=�6E   $��Italic$�6`   $
��Bold"�6s   �� 57      $�Relative��6   6-   d� 58      -   5        $��
GatingType��58      $��70��62   $��35��59      $��10q�5:      #��[  5;      $��Center=�6O    6l   �� *
GateType+�� 5<      $
��Auto��6   $
��Auto��6)   $��20(�67   $��Center=�6E   $��Italic$�6`   $
��Bold"�6s   �� 6�   $�Absolute Gate��6�   6�   5=      �� 5>      $��10,0,0,0q�6   $
��Bold"�6*   $��Center=�6<   $��Center=�6W   $��20(�6u   $��Italic$�6�   �� 6�   $�Gating Threshold��6�   6�   �� 5?      -   5        $ 	threshold��5?      $��30��6)   $
��Auto��65   $��0,0,0,10q�6B   $��Center=�6T   $��-1��6v   {�6�   �� $ 
GatingType��$ 	IsChecked��� 5@      $	��200��6   $��50��6!   $��15(�6-   $��	ExtraBold"�6;   ��6R   �� *	RunTool+.��6n   
Run Tool6x   �� 5A      $	��200��6   $��50��6!   $��15(�6-   $��	ExtraBold"�6;   ��6R   �� *Return+.��6m   Return6u   �� 5B      $	��100��6   $��30��6!   $��15(�6-   $
��Bold"�6;   $��Right=�6M   $��Bottom=�6i   ��6�   �� *Logout+.��6�   Logout6�   5C      �� 5E   
   $��1��6   $��Stretch=�6%   $	��Top=�6C   .+�5F      �� $��50��6C   $��Stretch=�6O    �� TextAlignment$ Center=�6m   $��30(�6�   $
��Bold"�6�   ��6   �� *Colour+$ OneWay=���6�   �� *Output+6�   �� 5G      $
��3000��6K   ��6   �� *AnalysisReport+$ OneWay=� �� View 5H      �� 5I      .P�5J      �� $��TypeId��6)    �� Width$	 100��69    �� CellTemplate 5K      �� 5L   "   .R�5M   &   �� $
��Wrap=�60   ��6D   �� *TypeId+5O   #   5Q      �� 5R      $��FileName��6)   $	 100��6;    5S      �� 5T   "   .R�5U   &   �� $
��Wrap=�60   ��6D   �� *
FileName+5W   #   5Y      �� 5Z      $��Message��6)   $	 500��6;    5[      �� 5\   "   .R�5]   &   �� $
��Wrap=�60   $��Stretch=�6D   ��6b   �� *	Message+5_   #   5a      �� 5b      $��LineNo��6)   $ 70��69    5c      �� 5d   "   .R�5e   &   �� $
��Wrap=�60   ��6D   �� *Line+5g   #   5i      5j      5l      5m      �� 5o   
   $��2��6    �� CanVerticallyScroll . .+�5p      �� $
��Bold"�6   $��Normal$�6+   $��25(�6>   $��Center=�6L   �� 6j   $�Recents��6n   6�   �� 5q      -   5         ��Name$ Recents��5q      ��6(   �� *	UserRepos+��5r      �� 5s      .R�5t      �� ��6%   �� $ Colour�.+�5u      �� $��15(�6(   �� 67   �6;   �� *
Repository+6[   �� 5v      �� 6)   $�Gating Result��6-   6E   5w      5x      5z      5{      5|      5}      