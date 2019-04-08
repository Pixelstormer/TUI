﻿namespace TUI.Base.Style
{
    public class LayoutStyle
    {
        /// <summary>
        /// Layout offset.
        /// </summary>
        public ExternalOffset Offset { get; set; }
        /// <summary>
        /// Object placing alignment in child layout. Looks to parent's grid default value if not present.
        /// </summary>
        public Alignment? Alignment { get; set; }
        /// <summary>
        /// Object placing direction in child layout. Looks to parent's grid default value if not present.
        /// </summary>
        public Direction? Direction { get; set; }
        /// <summary>
        /// Object placing side relative to direction in child layout. Looks to parent's grid default value if not present.
        /// </summary>
        public Side? Side { get; set; }
        /// <summary>
        /// Distance between objects in child layout. Looks to parent's grid default value if not present.
        /// </summary>
        public int? ChildIndent { get; set; }
    }

    public class PositioningStyle
    {
        /// <summary>
        /// If set to true and object has a parent then X and Y would be ignored, instead object
        /// would be positioned in parent's layout.
        /// </summary>
        public bool InLayout { get; set; } = false;
        /// <summary>
        /// Object size matches parent horizontal/vertical/both size automatically.
        /// If <see cref="FullSize"/> != None and <see cref="InLayout"/> == true then matching parent size consideres layout offset.
        /// </summary>
        public FullSize FullSize { get; set; } = FullSize.None;
    }

    public class GridStyle
    {
        public ISize[] Columns { get; internal set; }
        public ISize[] Lines { get; internal set; }
        internal int[] ColumnResultingSizes { get; set; }
        internal int[] LineResultingSizes { get; set; }
        public Offset Offset { get; set; }
        public ExternalOffset DefaultOffset { get; set; }
        public Alignment? DefaultAlignment { get; set; }
        public Direction? DefaultDirection { get; set; }
        public Side? DefaultSide { get; set; }
        public int? DefaultChildIndent { get; set; }

        public GridStyle(ISize[] columns = null, ISize[] lines = null)
        {
            Columns = columns ?? new ISize[] { new Relative(100) };
            Lines = lines ?? new ISize[] { new Relative(100) };
            ColumnResultingSizes = new int[Columns.Length];
            LineResultingSizes = new int[Lines.Length];
        }

        public GridStyle(GridStyle configuration)
            : this((ISize[]) configuration.Columns.Clone(), (ISize[]) configuration.Lines.Clone())
        {
        }
    }

    public class UIStyle
    {
        /// <summary>
        /// Child layout related styles.
        /// </summary>
        public LayoutStyle Layout { get; set; } = new LayoutStyle();
        /// <summary>
        /// Parent related positioning styles.
        /// </summary>
        public PositioningStyle Positioning { get; set; } = new PositioningStyle();
        /// <summary>
        /// Grid related styles. Null by default. Use <see cref="VisualDOM.SetupGrid(GridConfiguration, bool)"/> for initializing grid.
        /// </summary>
        public GridStyle Grid { get; internal set; }
        
        public bool? Active { get; set; }
        public ushort? Tile { get; set; }
        public byte? TileColor { get; set; }
        public byte? Wall { get; set; }
        public byte? WallColor { get; set; }
        public bool? InActive { get; set; }

        public UIStyle() { }

        public UIStyle(UIStyle style)
        {
            if (style.Active.HasValue)
                this.Active = style.Active.Value;
            if (style.Tile.HasValue)
                this.Tile = style.Tile.Value;
            if (style.TileColor.HasValue)
                this.TileColor = style.TileColor.Value;
            if (style.Wall.HasValue)
                this.Wall = style.Wall.Value;
            if (style.WallColor.HasValue)
                this.WallColor = style.WallColor.Value;
            if (style.InActive.HasValue)
                this.InActive = style.InActive.Value;
        }
    }
}