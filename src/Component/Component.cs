using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Skclusive.Core.Component
{
    public class Component : EventComponentBase
    {
        [Parameter]
        public string Tag { set; get; } = "div";

        [Parameter]
        public bool? NoWrap { set; get; }

        [Parameter]
        public IReference RootRef { set; get; } = new Reference();

        [Parameter]
        public IReference ChildRef { set; get; } = new Reference();

        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { get; set; }

        #region From BlazorComponent https://github.com/aspnet/Blazor/blob/5a50ce2e8f2332d7431d62509bfc439915dac8c9/src/Microsoft.AspNetCore.Blazor/Components/BlazorComponent.cs

        #endregion

        protected IComponentContext Context => new ComponentContextBuilder()
            // .WithClass(Class)
            // .WithStyle(Style)
            .WithRefBack(ChildRef)
            .WithDisabled(Disabled)
            .Build();

        public void Focus()
        {
            // TODO: implement focus using js introp
            // Element?.Focus();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            if (NoWrap.HasValue && NoWrap.Value)
            {
                BuildChildRenderTree(builder);
            }
            else
            {
                BuildElementRenderTree(builder);
            }
        }

        protected virtual void BuildChildRenderTree(RenderTreeBuilder builder)
        {
            if (ChildContent != null)
                builder.AddContent(1, ChildContent(Context));
        }

        protected virtual void BuildElementRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag);

            //foreach (var attribute in Attributes)
            //{
            //    builder.AddAttribute(1, attribute.Key, attribute.Value);
            //}

            builder.AddMultipleAttributes(1, Attributes);

            var _class = _Class;
            var _style = _Style;

            if (!string.IsNullOrWhiteSpace(Id))
                builder.AddAttribute(2, "id", Id);

            if (!string.IsNullOrWhiteSpace(_class))
                builder.AddAttribute(3, "class", _class);

            if (!string.IsNullOrWhiteSpace(_style))
                builder.AddAttribute(4, "style", _style);

            if (TabIndex.HasValue)
                builder.AddAttribute(5, "tabindex", Disabled.HasValue && Disabled.Value ? -1 : TabIndex);

            if (OnFocus.HasDelegate)
                builder.AddAttribute(6, "onfocus", EventCallback.Factory.Create<FocusEventArgs>(this, HandleFocusAsync));

            if (OnBlur.HasDelegate)
                builder.AddAttribute(7, "onblur", EventCallback.Factory.Create<FocusEventArgs>(this, HandleBlurAsync));

            if (OnKeyDown.HasDelegate)
                builder.AddAttribute(8, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>(this, HandleKeyDownAsync));

            if (OnKeyUp.HasDelegate)
                builder.AddAttribute(9, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>(this, HandleKeyUpAsync));

            if (OnMouseDown.HasDelegate)
                builder.AddAttribute(10, "onmousedown", EventCallback.Factory.Create<MouseEventArgs>(this, HandleMouseDownAsync));

            if (OnMouseUp.HasDelegate)
                builder.AddAttribute(11, "onmouseup", EventCallback.Factory.Create<MouseEventArgs>(this, HandleMouseUpAsync));

            if (OnMouseLeave.HasDelegate)
                builder.AddAttribute(12, "onmouseleave", EventCallback.Factory.Create<EventArgs>(this, HandleMouseLeaveAsync));

            if (OnTouchStart.HasDelegate)
                builder.AddAttribute(13, "ontouchstart", EventCallback.Factory.Create<TouchEventArgs>(this, HandleTouchStartAsync));

            if (OnTouchMove.HasDelegate)
                builder.AddAttribute(14, "ontouchmove", EventCallback.Factory.Create<TouchEventArgs>(this, HandleTouchMoveAsync));

            if (OnTouchEnd.HasDelegate)
                builder.AddAttribute(15, "ontouchend", EventCallback.Factory.Create<TouchEventArgs>(this, HandleTouchEndAsync));

            if (OnClick.HasDelegate)
                builder.AddAttribute(16, "onclick", EventCallback.Factory.Create<EventArgs>(this, HandleClickAsync));

            if(OnDrag.HasDelegate)
                builder.AddAttribute(17, "ondrag", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragAsync));

            if (OnDrop.HasDelegate)
                builder.AddAttribute(18, "ondrop", EventCallback.Factory.Create<DragEventArgs>(this, HandleDropAsync));

            if (OnDragStart.HasDelegate)
                builder.AddAttribute(19, "ondragstart", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragStartAsync));

            if (OnDragEnd.HasDelegate)
                builder.AddAttribute(20, "ondragend", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragEndAsync));

            if (OnDragEnter.HasDelegate)
                builder.AddAttribute(21, "ondragenter", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragEnterAsync));

            if (OnDragExit.HasDelegate)
                builder.AddAttribute(22, "ondragexit", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragExitAsync));

            if (OnDragOver.HasDelegate)
                builder.AddAttribute(23, "ondragover", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragOverAsync));

            if (OnDragLeave.HasDelegate)
                builder.AddAttribute(24, "ondragleave", EventCallback.Factory.Create<DragEventArgs>(this, HandleDragLeaveAsync));

            if (!string.IsNullOrWhiteSpace(Role))
                builder.AddAttribute(25, "role", Role);

            if (Disabled.HasValue)
                builder.AddAttribute(26, "disabled", Disabled.Value);

            if (ChildContent != null)
                builder.AddContent(27, ChildContent(Context));

            builder.AddElementReferenceCapture(28, (__value) => {
                RootRef.Current = (ElementReference)__value;
            });

            builder.CloseElement();
        }
    }
}
