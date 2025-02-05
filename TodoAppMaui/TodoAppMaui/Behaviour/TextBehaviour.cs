using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Behaviour
{
    class TextBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }
        private void Bindable_TextChanged(object? sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (entry.Text.Length>5 && entry.Text.Length<15)
            {
                entry.BackgroundColor=Colors.Transparent;
            }
            else
            {
                entry.BackgroundColor=Colors.Red;
            }
        }

    }
}
