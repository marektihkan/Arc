<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/TR/xhtml1/strict">
<xsl:output method="html"/>
	<xsl:template match="/">
		<xsl:choose>
			<!-- Apply the NCoverExplorer template if it exists in the input data -->
			<xsl:when test="//coverageReport">
				<xsl:apply-templates select="//coverageReport" />					
			</xsl:when>
			<!-- Otherwise apply the legacy NCover template if it exists in the input data -->
			<xsl:when test="//coverage">
				<xsl:apply-templates select="//coverage[count(module) != 0]" />					
			</xsl:when>
		</xsl:choose>
	</xsl:template>
	
	<!-- NCoverExplorer summary -->
	<xsl:template match="coverageReport">
        <table class="section-table" cellpadding="2" cellspacing="0" border="0" width="98%">
            <tr>
                <td class="sectionheader" colspan="4">
                   NCoverExplorer Code Coverage Summary: <xsl:value-of select="./project/@name"/>
                </td>
            </tr>
            <tr>
				<td class="header-label" width="300px">
					Module
					<br/><img src="..\images\shim.gif" width="300px" height="1px" />
				</td>
 				<td class="header-label" width="100px">
					Coverage %
					<br/><img src="..\images\shim.gif" width="100px" height="1px" />
				</td>
				<td class="header-label" width="110px">
					Acceptance %
					<br/><img src="..\images\shim.gif" width="110px" height="1px" />
				</td>
				<td class="header-label" width="100%">
					Verdict
				</td>
			</tr>
			<xsl:for-each select="./modules/module">
				<xsl:call-template name="ModuleSummary" />
			</xsl:for-each>
            <tr>
				<td class="header-label">
					<xsl:value-of select="./project/@name"/>&#160;Total
				</td>
				<td class="header-label">
					<xsl:value-of select="format-number(./project/@coverage, '0.0')"/>%
				</td>
				<td class="header-label">
					<xsl:value-of select="./project/@acceptable"/>%
				</td>
				<td class="header-label">
                   <xsl:if test="./project/@coverage &lt; ./project/@acceptable">
					  <span style="color:red">FAIL</span>
                   </xsl:if>
                   <xsl:if test="./project/@coverage &gt;= ./project/@acceptable">
					  <span style="color:green">PASS</span>
                   </xsl:if>
				</td>
			</tr>
			<tr>
				<td colspan="4">&#160;</td>
			</tr>
            <tr class="section-oddrow">
				<td>
					Unvisited Sequence Points: 
				</td>
 				<td>
					<xsl:value-of select="./project/@unvisitedPoints"/>
				</td>
				<td>
					Files: 
				</td>
				<td>
					<xsl:value-of select="./project/@files"/>
				</td>
            </tr>
            <tr>
				<td>
					Total Sequence Points:
				</td>
 				<td>
					<xsl:value-of select="./project/@sequencePoints"/>
				</td>
 				<td>
					Classes
				</td>
				<td>
					<xsl:value-of select="./project/@classes"/>
				</td>
           </tr>
            <tr class="section-oddrow">
  				<td>
					Non Comment Lines:
				</td>
				<td>
					<xsl:value-of select="./project/@nonCommentLines"/>
				</td>
 				<td>
					Functions:
				</td>
				<td>
					<xsl:value-of select="./project/@members"/>
				</td>
            </tr>
		</table>
	</xsl:template>
	
	<!-- Display a summary of each module and whether it passed -->
	<xsl:template name="ModuleSummary">
            <tr>
            <xsl:if test="position() mod 2 = 1">
                <xsl:attribute name="class">section-oddrow</xsl:attribute>
            </xsl:if>
				<td>
					<xsl:value-of select="@name"/>
				</td>
 				<td>
					<xsl:value-of select="format-number(@coverage, '0.0')"/>%
				</td>
				<td>
					<xsl:value-of select="@acceptable"/>%
				</td>
                <td>
                   <xsl:if test="@coverage &lt; @acceptable">
					  <span style="color:red">FAIL</span>
                   </xsl:if>
                   <xsl:if test="@coverage &gt;= @acceptable">
					  <span style="color:green">PASS</span>
                   </xsl:if>
                </td>
            </tr>
	</xsl:template>
	
	<!-- Legacy NCover summary -->
	<xsl:template match="coverage">
		<xsl:variable name="covered.lines" select="count(//coverage/module/method/seqpnt[@visitcount > 0])" />
		<xsl:variable name="uncovered.lines" select="count(//coverage/module/method/seqpnt[@visitcount = 0])" />
	
        <table class="section-table" cellpadding="2" cellspacing="0" border="0" width="98%">
            <tr>
                <td class="sectionheader" colspan="3">
                   NCover results:
                </td>
            </tr>
            <tr>
				<td>
					Covered lines: <xsl:value-of select="$covered.lines"/>
				</td>
				<td>
					Uncovered lines: <xsl:value-of select="$uncovered.lines"/>
				</td>
				<td>
					Total coverage: <xsl:value-of select="round($covered.lines div ($uncovered.lines + $covered.lines) * 100)"/>%
				</td>
            </tr>
		</table>
	</xsl:template>
</xsl:stylesheet>
