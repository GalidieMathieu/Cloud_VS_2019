import React, { Component } from 'react';

export class Query5 extends Component {
   static displayName = Query5.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateQuery5Data();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>departement</th>
            <th>total</th>
            <th>total amount</th>
            <th>moyenne des salaires</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.iD}>
                  <td>{forecast.dept}</td>
                  <td>{forecast.sum.toString()}</td>
                  <td>{forecast.totalAmount.toString()}</td>
                  <td>{forecast.moyenne_salaire.toString()}</td>    
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Query5.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Query 5</h1>
            <p>Moyenne du salaire par departement.</p>
        {contents}
      </div>
    );
  }

  async populateQuery5Data() {
    const response = await fetch('Query5');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
