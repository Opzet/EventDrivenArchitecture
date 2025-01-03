<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="c39766e4-dfb7-4409-adcf-33474a4d60e2" Description="Description for Company.ReportLanguage.ReportLanguage" Name="ReportLanguage" DisplayName="ReportLanguage" Namespace="Company.ReportLanguage" ProductName="ReportLanguage" CompanyName="Company" PackageGuid="68d426da-855a-444b-ab61-2d36420528df" PackageNamespace="Company.ReportLanguage" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="7b7308ec-a51e-44c4-b56e-2ff4c7a963fe" Description="The root in which all other elements are embedded. Appears as a diagram." Name="ReportModel" DisplayName="Report Model" Namespace="Company.ReportLanguage">
      <Properties>
        <DomainProperty Id="67d2b042-5e6d-4a33-8a24-41f099b55bda" Description="Description for Company.ReportLanguage.ReportModel.Name Of Project" Name="NameOfProject" DisplayName="Name Of Project">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Notes>Creates an embedding link when an element is dropped onto a model. </Notes>
          <Index>
            <DomainClassMoniker Name="Report" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ReportModelHasElements.Elements</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Generator" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ReportModelHasGenerators.Generators</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="7a0b26f8-59b0-4c2d-870d-abac40e0edd8" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="Report" DisplayName="Report" Namespace="Company.ReportLanguage">
      <Properties>
        <DomainProperty Id="289a1818-e2e0-499a-8d0d-ea5f86584ee8" Description="Description for Company.ReportLanguage.Report.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="61b35599-ce49-42f3-a2b3-3f1df2d8986e" Description="Description for Company.ReportLanguage.Report.Specification URL" Name="SpecificationURL" DisplayName="Specification URL">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c7a42086-bcf1-4413-a014-4b46bf0718f7" Description="Description for Company.ReportLanguage.Report.Author" Name="Author" DisplayName="Author">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="3c7bb38f-5b90-4828-a235-196867f21764" Description="Description for Company.ReportLanguage.Generator" Name="Generator" DisplayName="Generator" Namespace="Company.ReportLanguage">
      <Properties>
        <DomainProperty Id="c3b0f8a0-7ddb-490e-aad2-2625bfcc13cf" Description="Description for Company.ReportLanguage.Generator.Name" Name="Name" DisplayName="Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a1627a2f-eaf2-4594-828f-7441a398ab41" Description="Description for Company.ReportLanguage.Generator.Assembly Name" Name="AssemblyName" DisplayName="Assembly Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="652d9ccf-3082-4da0-8099-d3d794acb896" Description="Description for Company.ReportLanguage.Generator.Assembly Location" Name="AssemblyLocation" DisplayName="Assembly Location">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b9319e73-adf1-439e-bde3-91c3d733a2f7" Description="Description for Company.ReportLanguage.Generator.Class Name" Name="ClassName" DisplayName="Class Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="41b9b439-1f67-4b8c-9598-33b86ac6b5ea" Description="Embedding relationship between the Model and Elements" Name="ReportModelHasElements" DisplayName="Report Model Has Elements" Namespace="Company.ReportLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="b2574a1d-6fe1-4fce-9a59-be33f1c34aaa" Description="" Name="ReportModel" DisplayName="Report Model" PropertyName="Elements" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Elements">
          <RolePlayer>
            <DomainClassMoniker Name="ReportModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="67df2067-166c-4bce-bf8c-74a147939869" Description="" Name="Element" DisplayName="Element" PropertyName="ReportModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Report Model">
          <RolePlayer>
            <DomainClassMoniker Name="Report" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="14fe1330-6ca0-4a7d-8f66-83abc8e1dc9e" Description="Reference relationship between Elements." Name="ReportReferencesReports" DisplayName="Report References Reports" Namespace="Company.ReportLanguage">
      <Source>
        <DomainRole Id="d2ac6cc4-3d35-446b-9141-4bb9a57e85f3" Description="Description for Company.ReportLanguage.ExampleRelationship.Target" Name="Source" DisplayName="Source" PropertyName="Targets" PropertyDisplayName="Targets">
          <RolePlayer>
            <DomainClassMoniker Name="Report" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="f928e7c0-122c-492e-b58d-377de6c0e9e2" Description="Description for Company.ReportLanguage.ExampleRelationship.Source" Name="Target" DisplayName="Target" PropertyName="Sources" PropertyDisplayName="Sources">
          <RolePlayer>
            <DomainClassMoniker Name="Report" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="27aa1f02-2f45-4b8d-9094-85a4c1ccd8ac" Description="Description for Company.ReportLanguage.ReportModelHasGenerators" Name="ReportModelHasGenerators" DisplayName="Report Model Has Generators" Namespace="Company.ReportLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="0fd2cdae-38c0-4dd4-939c-53229d7b92eb" Description="Description for Company.ReportLanguage.ReportModelHasGenerators.ReportModel" Name="ReportModel" DisplayName="Report Model" PropertyName="Generators" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Generators">
          <RolePlayer>
            <DomainClassMoniker Name="ReportModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="84d1bdc6-8448-472f-a813-c3139d1b59c0" Description="Description for Company.ReportLanguage.ReportModelHasGenerators.Generator" Name="Generator" DisplayName="Generator" PropertyName="ReportModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Report Model">
          <RolePlayer>
            <DomainClassMoniker Name="Generator" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="5ef0c1c0-c67b-4615-abd2-c2842d760f12" Description="Description for Company.ReportLanguage.ReportReferencesGenerators" Name="ReportReferencesGenerators" DisplayName="Report References Generators" Namespace="Company.ReportLanguage">
      <Source>
        <DomainRole Id="dc1dd15e-7dac-44fd-9fd7-a576bf7b10de" Description="Description for Company.ReportLanguage.ReportReferencesGenerators.Report" Name="Report" DisplayName="Report" PropertyName="Generators" PropertyDisplayName="Generators">
          <RolePlayer>
            <DomainClassMoniker Name="Report" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9b2adef3-8de2-4693-a6d1-df1ba5a86ab5" Description="Description for Company.ReportLanguage.ReportReferencesGenerators.Generator" Name="Generator" DisplayName="Generator" PropertyName="Reported" PropertyDisplayName="Reported">
          <RolePlayer>
            <DomainClassMoniker Name="Generator" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <Shapes>
    <GeometryShape Id="3c86c8d5-7418-402e-ab13-d09448efcad0" Description="Shape used to represent ExampleElements on a Diagram." Name="ReportShape" DisplayName="Report Shape" Namespace="Company.ReportLanguage" FixedTooltipText="Report Shape" FillColor="242, 239, 229" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="SpecificationURLDecorator" DisplayName="Specification URL Decorator" DefaultText="SpecificationURLDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="AuthorDecorator" DisplayName="Author Decorator" DefaultText="AuthorDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="0c48dbfa-3530-40a3-aaee-c236331511d3" Description="Description for Company.ReportLanguage.GeneratorShape" Name="GeneratorShape" DisplayName="Generator Shape" Namespace="Company.ReportLanguage" FixedTooltipText="Generator Shape" InitialHeight="1" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="AssemblyNameDecorator" DisplayName="Assembly Name Decorator" DefaultText="AssemblyNameDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="AssemblyLocationDecorator" DisplayName="Assembly Location Decorator" DefaultText="AssemblyLocationDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="ClassNameDecorator" DisplayName="Class Name Decorator" DefaultText="ClassNameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="52d90805-d15b-4ab1-a26c-ec4a1dab92dd" Description="Connector between Reports. Represents Report-References-Report relationship on the Diagram." Name="ReportToReportConnector" DisplayName="Report To Report Connector" Namespace="Company.ReportLanguage" FixedTooltipText="Report To Report Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01" />
    <Connector Id="b156b169-e4ab-4702-9a58-5ec26eb95b51" Description="Description for Company.ReportLanguage.ReportToGeneratorConnector" Name="ReportToGeneratorConnector" DisplayName="Report To Generator Connector" Namespace="Company.ReportLanguage" FixedTooltipText="Report To Generator Connector" />
  </Connectors>
  <XmlSerializationBehavior Name="ReportLanguageSerializationBehavior" Namespace="Company.ReportLanguage">
    <ClassData>
      <XmlClassData TypeName="ReportModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportModelMoniker" ElementName="reportModel" MonikerTypeName="ReportModelMoniker">
        <DomainClassMoniker Name="ReportModel" />
        <ElementData>
          <XmlRelationshipData RoleElementName="elements">
            <DomainRelationshipMoniker Name="ReportModelHasElements" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="nameOfProject">
            <DomainPropertyMoniker Name="ReportModel/NameOfProject" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="generators">
            <DomainRelationshipMoniker Name="ReportModelHasGenerators" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Report" MonikerAttributeName="name" SerializeId="true" MonikerElementName="reportMoniker" ElementName="report" MonikerTypeName="ReportMoniker">
        <DomainClassMoniker Name="Report" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Report/Name" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="targets">
            <DomainRelationshipMoniker Name="ReportReferencesReports" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="specificationURL">
            <DomainPropertyMoniker Name="Report/SpecificationURL" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="author">
            <DomainPropertyMoniker Name="Report/Author" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="generators">
            <DomainRelationshipMoniker Name="ReportReferencesGenerators" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ReportModelHasElements" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportModelHasElementsMoniker" ElementName="reportModelHasElements" MonikerTypeName="ReportModelHasElementsMoniker">
        <DomainRelationshipMoniker Name="ReportModelHasElements" />
      </XmlClassData>
      <XmlClassData TypeName="ReportReferencesReports" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportReferencesReportsMoniker" ElementName="reportReferencesReports" MonikerTypeName="ReportReferencesReportsMoniker">
        <DomainRelationshipMoniker Name="ReportReferencesReports" />
      </XmlClassData>
      <XmlClassData TypeName="ReportShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportShapeMoniker" ElementName="reportShape" MonikerTypeName="ReportShapeMoniker">
        <GeometryShapeMoniker Name="ReportShape" />
      </XmlClassData>
      <XmlClassData TypeName="ReportToReportConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportToReportConnectorMoniker" ElementName="reportToReportConnector" MonikerTypeName="ReportToReportConnectorMoniker">
        <ConnectorMoniker Name="ReportToReportConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ReportLanguageDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportLanguageDiagramMoniker" ElementName="reportLanguageDiagram" MonikerTypeName="ReportLanguageDiagramMoniker">
        <DiagramMoniker Name="ReportLanguageDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Generator" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatorMoniker" ElementName="generator" MonikerTypeName="GeneratorMoniker">
        <DomainClassMoniker Name="Generator" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="Generator/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="assemblyName">
            <DomainPropertyMoniker Name="Generator/AssemblyName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="assemblyLocation">
            <DomainPropertyMoniker Name="Generator/AssemblyLocation" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="className">
            <DomainPropertyMoniker Name="Generator/ClassName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="GeneratorShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatorShapeMoniker" ElementName="generatorShape" MonikerTypeName="GeneratorShapeMoniker">
        <GeometryShapeMoniker Name="GeneratorShape" />
      </XmlClassData>
      <XmlClassData TypeName="ReportModelHasGenerators" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportModelHasGeneratorsMoniker" ElementName="reportModelHasGenerators" MonikerTypeName="ReportModelHasGeneratorsMoniker">
        <DomainRelationshipMoniker Name="ReportModelHasGenerators" />
      </XmlClassData>
      <XmlClassData TypeName="ReportReferencesGenerators" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportReferencesGeneratorsMoniker" ElementName="reportReferencesGenerators" MonikerTypeName="ReportReferencesGeneratorsMoniker">
        <DomainRelationshipMoniker Name="ReportReferencesGenerators" />
      </XmlClassData>
      <XmlClassData TypeName="ReportToGeneratorConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="reportToGeneratorConnectorMoniker" ElementName="reportToGeneratorConnector" MonikerTypeName="ReportToGeneratorConnectorMoniker">
        <ConnectorMoniker Name="ReportToGeneratorConnector" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ReportLanguageExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="ReportReferencesReportsBuilder">
      <Notes>Provides for the creation of an ExampleRelationship by pointing at two ExampleElements.</Notes>
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ReportReferencesReports" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Report" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Report" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ReportReferencesGeneratorsBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ReportReferencesGenerators" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Report" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Generator" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="2eb3b2b7-a786-4260-a93d-d9c079aa8a58" Description="Description for Company.ReportLanguage.ReportLanguageDiagram" Name="ReportLanguageDiagram" DisplayName="Minimal Language Diagram" Namespace="Company.ReportLanguage">
    <Class>
      <DomainClassMoniker Name="ReportModel" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="Report" />
        <ParentElementPath>
          <DomainPath>ReportModelHasElements.ReportModel/!ReportModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ReportShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Report/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ReportShape/SpecificationURLDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Report/SpecificationURL" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ReportShape/AuthorDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Report/Author" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="ReportShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Generator" />
        <ParentElementPath>
          <DomainPath>ReportModelHasGenerators.ReportModel/!ReportModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="GeneratorShape/AssemblyLocationDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Generator/AssemblyLocation" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="GeneratorShape/AssemblyNameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Generator/AssemblyName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="GeneratorShape/ClassNameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Generator/ClassName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="GeneratorShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Generator/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="GeneratorShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="ReportToReportConnector" />
        <DomainRelationshipMoniker Name="ReportReferencesReports" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="ReportToGeneratorConnector" />
        <DomainRelationshipMoniker Name="ReportReferencesGenerators" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="report" EditorGuid="eebda064-7412-4382-a11d-923503b240a1">
    <RootClass>
      <DomainClassMoniker Name="ReportModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="ReportLanguageSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="Reports">
      <ElementTool Name="ReportElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="Report Element" Tooltip="Create a Report Element" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="Report" />
      </ElementTool>
      <ConnectionTool Name="ReportRelationship" ToolboxIcon="resources\exampleconnectortoolbitmap.bmp" Caption="Report Relationship" Tooltip="Drag between Reports" HelpKeyword="ConnectExampleRelationF1Keyword">
        <ConnectionBuilderMoniker Name="ReportLanguage/ReportReferencesReportsBuilder" />
      </ConnectionTool>
      <ElementTool Name="GeneratorElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="Generator Element" Tooltip="Create a Generator Element" HelpKeyword="GeneratorElement">
        <DomainClassMoniker Name="Generator" />
      </ElementTool>
      <ConnectionTool Name="GeneratorRelationship" ToolboxIcon="resources\exampleconnectortoolbitmap.bmp" Caption="Generator Relationship" Tooltip="Drag from Report to Generator" HelpKeyword="GeneratorRelationship">
        <ConnectionBuilderMoniker Name="ReportLanguage/ReportReferencesGeneratorsBuilder" />
      </ConnectionTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="ReportLanguageDiagram" />
  </Designer>
  <Explorer ExplorerGuid="c1102562-567a-47a1-ae34-a1862089ee92" Title="ReportLanguage Explorer">
    <ExplorerBehaviorMoniker Name="ReportLanguage/ReportLanguageExplorer" />
  </Explorer>
</Dsl>