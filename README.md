# ginastica-laboral [![Build status](https://ci.appveyor.com/api/projects/status/3i5rkpmu9cbkgg3o/branch/master?svg=true)](https://ci.appveyor.com/project/fmmsilva/ginastica-laboral/branch/master)

Aplicação para exibição da campanha de Ginástica Laboral

## Como configurar os slides?
Crie uma subpasta "slides" dentro da pasta do aplicativo e nomeie os arquivos na sequência:
- slide.00.jpg
- slide.01.jpg
- slide.02.jpg
- ...
- slide.99.jpg

## Como configurar os horários de exibição da campanha?
Os horários de exibição da campanha podem ser configurados atravês do arquivo ***GinasticaLaboral.exe.config*** que deve seguir o padrão abaixo:

```xml
<?xml version="1.0"?>
<configuration>
  <configSections>
    <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
      <section name="GinasticaLaboral.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
    </sectionGroup>
  </configSections>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
  </startup>
  <applicationSettings>
    <GinasticaLaboral.Properties.Settings>
      <setting name="Horarios" serializeAs="Xml">
        <value>
          <ArrayOfString xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <string>08:30</string>
            <string>11:30</string>
            <string>12:30</string>
            <string>15:30</string>
            <string>18:30</string>
          </ArrayOfString>
        </value>
      </setting>
    </GinasticaLaboral.Properties.Settings>
  </applicationSettings>
</configuration>
```

## Como utilizar a aplicação?

Após executados os passos acima, configure a aplicação para ser executada no script de logon.
