using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelFriend.Chat.Models
{
    public partial class TravelFriendContext : DbContext
    {
        public TravelFriendContext()
        {
        }

        public TravelFriendContext(DbContextOptions<TravelFriendContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlbumImages> AlbumImages { get; set; }
        public virtual DbSet<TeamAlbum> TeamAlbum { get; set; }
        public virtual DbSet<TeamMember> TeamMember { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAlbum> UserAlbum { get; set; }
        public virtual DbSet<UserTeam> UserTeam { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=47.106.139.187;database=TravelFriend;uid=root;pwd=lxyLXY04/111997", x => x.ServerVersion("5.7.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumImages>(entity =>
            {
                entity.ToTable("album_images");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("images_album_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("照片ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AlbumId)
                    .IsRequired()
                    .HasColumnName("album_id")
                    .HasColumnType("char(255)")
                    .HasComment("相册ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompressImage)
                    .HasColumnName("compress_image")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户相册压缩地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户照片地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户视频地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumImages)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("images_album_id");
            });

            modelBuilder.Entity<TeamAlbum>(entity =>
            {
                entity.ToTable("team_album");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("团队相册id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Albumname)
                    .HasColumnName("albumname")
                    .HasColumnType("varchar(255)")
                    .HasComment("相册名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompressCover)
                    .HasColumnName("compress_cover")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("varchar(11)")
                    .HasComment("相册内照片计数")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cover)
                    .HasColumnName("cover")
                    .HasColumnType("varchar(255)")
                    .HasComment("相册封面")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Introduction)
                    .HasColumnName("introduction")
                    .HasColumnType("varchar(255)")
                    .HasComment("相册简介")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TeamId)
                    .IsRequired()
                    .HasColumnName("team_id")
                    .HasColumnType("char(255)")
                    .HasComment("相册所属团队id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.ToTable("team_member");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("队员id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Isleader)
                    .HasColumnName("isleader")
                    .HasColumnType("varchar(255)")
                    .HasComment("是否为队长")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberName)
                    .HasColumnName("member_name")
                    .HasColumnType("varchar(255)")
                    .HasComment("队员姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberNickname)
                    .HasColumnName("member_nickname")
                    .HasColumnType("varchar(255)")
                    .HasComment("队友昵称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasColumnType("varchar(255)")
                    .HasComment("队员所属团队的id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("testID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TestString)
                    .HasColumnName("testString")
                    .HasColumnType("char(255)")
                    .HasComment("testString")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("用户ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户头像地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户生日")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompressAvatar)
                    .HasColumnName("compress_avatar")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户头像缩略图地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户性别（0女1男）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户昵称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户密码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户个签")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UserAlbum>(entity =>
            {
                entity.ToTable("user_album");

                entity.HasIndex(e => e.UserId)
                    .HasName("album_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("用户相册ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Albumname)
                    .HasColumnName("albumname")
                    .HasColumnType("varchar(255)")
                    .HasComment("相册名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cover)
                    .HasColumnName("cover")
                    .HasColumnType("varchar(255)")
                    .HasComment("相册封面")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Introduction)
                    .HasColumnName("introduction")
                    .HasColumnType("varchar(255)")
                    .HasComment("相册描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("char(255)")
                    .HasComment("用户ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAlbum)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("album_user_id");
            });

            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.ToTable("user_team");

                entity.HasIndex(e => e.UserId)
                    .HasName("team_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("团队ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasColumnType("varchar(255)")
                    .HasComment("团队头像URL")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompressAvatar)
                    .HasColumnName("compress_avatar")
                    .HasColumnType("varchar(255)")
                    .HasComment("团队头像缩略图URL")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Introduction)
                    .HasColumnName("introduction")
                    .HasColumnType("varchar(255)")
                    .HasComment("团队简介")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TeamName)
                    .HasColumnName("team_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("char(255)")
                    .HasComment("团队成员ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTeam)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("team_user_id");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.ToTable("user_token");

                entity.HasIndex(e => e.UserId)
                    .HasName("token_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(255)")
                    .HasComment("用户TokenID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(255)")
                    .HasComment("Token值")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("char(255)")
                    .HasComment("用户ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserToken)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("token_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
