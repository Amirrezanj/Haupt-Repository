using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TodoAppMaui.Behaviour
{
    public class EmailBehaviour : Behavior<Entry>
    {
        private static readonly Regex EmailRegex =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry == null) return;

            bool isValid = EmailRegex.IsMatch(entry.Text);
            if (isValid)
            {
                 entry.BackgroundColor = Colors.Transparent;
            }
            else
            {
                entry.BackgroundColor = Colors.Red;

            }

            //entry.TextColor = isValid ? Colors.Transparent : Colors.Red;
        }
    }
}
