import React, { Component } from 'react';

export class Query3 extends Component {
  static displayName = Query3.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>first name</th>
            <th>last name</th>
            <th>dept</th>
            <th>salaire</th>
            <th>job name</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.Id}>
                  <td>{forecast.first_name}</td>
                  <td>{forecast.last_name}</td>
                  <td>{forecast.dept[forecast.dept.length - 1].dept_no}</td>
                  <td>{forecast.salaries[forecast.salaries.length - 1].salary}</td>
                  <td>{forecast.titles[forecast.titles.length - 1].title}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Query3.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Query 3</h1>
            <p>informations sur l'employe id : 10001</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('Query3');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
