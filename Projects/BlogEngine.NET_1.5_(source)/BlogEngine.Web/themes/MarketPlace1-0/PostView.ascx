<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PostView.ascx.cs" Inherits="themes_MarketPlace1_0_PostView" %>
<div class="post">
            <div class="entry-wrap">
			<h1><a href="<%=Post.RelativeLink %>" title="<%= Post.Title %>" rel="bookmark">
                <%=Post.Title %>
            </a></h1>
</div>
			<div class="post-by">Posted by <a href="<%=VirtualPathUtility.ToAbsolute("~/") + "author/" + Post.Author %>.aspx">
                <%=Post.Author %>
            </a></div>
			<asp:PlaceHolder ID="BodyContent" runat="server" />
            <div class="rating">
                <%=Rating %>
            </div>
            <div class="info">
            Posted on:
            <%= Post.DateCreated.ToShortDateString() + " at " + Post.DateCreated.ToShortTimeString() %>
            <br />
            <%= GetLinksWithLabel("Tags:  ", TagLinks(", ")) %>
            <%= GetLinksWithLabel("Categories:  ", CategoryLinks(" | ")) %>
            Actions: <a rel="nofollow" href="mailto:?subject=<%=Post.Title %>&amp;body=Thought you might like this: <%=Post.AbsoluteLink.ToString() %>">
                E-mail</a> | <a rel="nofollow" href="http://www.dotnetkicks.com/submit?url=<%=Server.UrlEncode(Post.AbsoluteLink.ToString()) %>&amp;title=<%=Server.UrlEncode(Post.Title) %>">
                    Kick it!</a> | <a rel="nofollow" href="http://www.dzone.com/links/add.html?url=<%=Server.UrlEncode(Post.AbsoluteLink.ToString()) %>&amp;title=<%=Server.UrlEncode(Post.Title) %>">
                        DZone it!</a> | <a rel="nofollow" href="http://del.icio.us/post?url=<%=Server.UrlEncode(Post.AbsoluteLink.ToString()) %>&amp;title=<%=Server.UrlEncode(Post.Title) %>">
                            del.icio.us</a><br />
            Post Information: <a rel="bookmark" href="<%=Post.PermaLink %>">Permalink</a> |
            <a rel="nofollow" href="<%=Post.RelativeLink %>#comment">
                <%=Resources.labels.comments %>
                (<%=Post.ApprovedComments.Count %>)</a> | <a rel="nofollow" href="<%=CommentFeed %>">
                    Post RSS<asp:Image ID="Image1" runat="Server" ImageUrl="~/pics/rssButton.gif" AlternateText="RSS comment feed"
                        Style="margin-left: 3px" /></a><br />
            <%= GetLinksWithLabel("Administration:  ", AdminLinks) %>
        </div>
</div>
