﻿using System.Linq;
using SadConsole.Effects;

namespace SadConsole
{
    public partial class ColoredString
    {
        /// <summary>
        /// A <see cref="ColoredGlyph"/> with a <see cref="ICellEffect"/>.
        /// </summary>
        public class ColoredGlyphEffect: ColoredGlyph
        {
            ICellEffect _effect;

            /// <summary>
            /// The effect of this cell.
            /// </summary>
            public ICellEffect Effect
            {
                get => _effect;
                set
                {
                    _effect = value;
                    IsDirty = true;
                }
            }

            /// <summary>
            /// Creates a copy of this <see cref="ColoredGlyphEffect"/>.
            /// </summary>
            /// <returns>A copy of this <see cref="ColoredGlyphEffect"/>.</returns>
            public new ColoredGlyphEffect Clone()
            {
                return new ColoredGlyphEffect()
                {
                    Foreground = Foreground,
                    Background = Background,
                    Glyph = Glyph,
                    Mirror = Mirror,
                    Effect = Effect,
                    Decorators = Decorators.ToArray()
                };
            }

            /// <summary>
            /// Creates a new <see cref="ColoredGlyphEffect"/> from a <see cref="ColoredGlyph"/> with the specified effect.
            /// </summary>
            /// <param name="glyph">The glyph.</param>
            /// <param name="effect">When provided, sets the <see cref="ColoredGlyphEffect.Effect"/>.</param>
            /// <returns></returns>
            public static ColoredGlyphEffect FromColoredGlyph(ColoredGlyph glyph, ICellEffect effect = null) =>
                new ColoredGlyphEffect() { Foreground = glyph.Foreground, Background = glyph.Background, Glyph = glyph.Glyph, Decorators = glyph.Decorators.ToArray(), Effect = effect };

            /// <summary>
            /// Copies the visual appearance to the specified cell. This includes foreground, background, glyph, mirror effect and decorators.
            /// </summary>
            /// <param name="cell">The target cell to copy to.</param>
            /// <param name="deepCopy">
            /// Whether to perform a deep copy.  Decorators are copied to a new array when true; when false, the old
            /// decorator array reference is moved directly.
            /// </param>
            public void CopyAppearanceTo(ColoredGlyphEffect cell, bool deepCopy = true)
            {
                cell.Foreground = Foreground;
                cell.Background = Background;
                cell.Glyph = Glyph;
                cell.Mirror = Mirror;
                cell.Effect = Effect;

                if (deepCopy)
                    cell.Decorators = Decorators.Length != 0 ? Decorators.ToArray() : System.Array.Empty<CellDecorator>();
                else
                    cell.Decorators = Decorators;
            }

            /// <summary>
            /// Sets the foreground, background, glyph, mirror effect and decorators to the same as the specified cell.
            /// </summary>
            /// <param name="cell">The target cell to copy from.</param>
            /// <param name="deepCopy">
            /// Whether to perform a deep copy.  Decorators are copied to a new array when true; when false, the old
            /// decorator array reference is moved directly.
            /// </param>
            public void CopyAppearanceFrom(ColoredGlyphEffect cell, bool deepCopy = true)
            {
                Foreground = cell.Foreground;
                Background = cell.Background;
                Glyph = cell.Glyph;
                Mirror = cell.Mirror;
                Effect = cell.Effect;

                if (deepCopy)
                    Decorators = cell.Decorators.Length != 0 ? cell.Decorators.ToArray() : System.Array.Empty<CellDecorator>();
                else
                    Decorators = cell.Decorators;
            }
        }

        
    }        
}
