using Sandbox.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace UnoGame.UI.Components
{
	public partial class Button : Sandbox.UI.Button
	{
		public Button()
		{
			StyleSheet.Load( "UI/Components/Button.scss" );
			AddEventListener( "OnMouseOver", OnMouseOver );
			AddEventListener( "OnMouseOut", OnMouseOut );
		}

		private void OnMouseOver()
		{
			AddClass( "hover" );
		}

		private void OnMouseOut()
		{
			RemoveClass( "hover" );
		}

		protected override void OnClick( MousePanelEvent e )
		{
			base.OnClick( e );
		}
	}
}
