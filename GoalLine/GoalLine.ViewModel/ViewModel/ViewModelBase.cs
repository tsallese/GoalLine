namespace GoalLine.ViewModel.ViewModel
{
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        #region Selected Item

        private static object _selectedItem = null;
        // This is public get-only here but you could implement a public setter which also selects the item.
        // Also this should be moved to an instance property on a VM for the whole tree, otherwise there will be conflicts for more than one tree.

        public static object SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
                if (_isSelected)
                {
                    SelectedItem = this;
                }
            }
        }

        #endregion
    }
}
